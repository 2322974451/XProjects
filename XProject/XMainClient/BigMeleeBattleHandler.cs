using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B98 RID: 2968
	internal class BigMeleeBattleHandler : DlgHandlerBase
	{
		// Token: 0x1700303D RID: 12349
		// (get) Token: 0x0600AA4E RID: 43598 RVA: 0x001E70B4 File Offset: 0x001E52B4
		protected override string FileName
		{
			get
			{
				return "Battle/BigMeleeBattle";
			}
		}

		// Token: 0x0600AA4F RID: 43599 RVA: 0x001E70CC File Offset: 0x001E52CC
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XBigMeleeBattleDocument>(XBigMeleeBattleDocument.uuID);
			this.doc.battleHandler = this;
			this.m_VS = (base.transform.FindChild("VS/Tex").GetComponent("XUITexture") as IXUITexture);
			this.m_VSLabel = (base.transform.FindChild("VS/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_ReviveTime = (base.transform.FindChild("ReviveTime").GetComponent("XUILabel") as IXUILabel);
			this.m_Time = (base.transform.FindChild("Time").GetComponent("XUILabel") as IXUILabel);
			this.m_PointRewardTips = (base.transform.FindChild("PointRewardTips").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.Find("RankPanel");
			this.m_MyRank = (transform.Find("MyInfo/Rank").GetComponent("XUILabel") as IXUILabel);
			this.m_MyName = (transform.Find("MyInfo/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_MyValue = (transform.Find("MyInfo/Value").GetComponent("XUILabel") as IXUILabel);
			this.m_RankBtn = (transform.Find("RankBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_Tween = (transform.gameObject.GetComponent("XUIPlayTween") as IXUITweenTool);
			Transform transform2 = transform.FindChild("RankTpl");
			this.m_RankPool.SetupPool(null, transform2.gameObject, 5U, false);
			this._ReviveCounter = new XLeftTimeCounter(this.m_ReviveTime, true);
			this._ReviveCounter.SetTimeFormat(1, 3, 4, false);
			this.m_Time.SetText(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_BEGIN_WAIT_TIP"));
			this._TimeCounter = new XLeftTimeCounter(this.m_Time, false);
			XBigMeleeEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XBigMeleeEntranceDocument>(XBigMeleeEntranceDocument.uuID);
			this.PointRewardList = specificDocument.GetPointRewardList();
			this.m_Point = (base.transform.FindChild("Point").GetComponent("XUILabel") as IXUILabel);
			this.m_PlayTween = (this.m_Point.gameObject.GetComponent("XUIPlayTween") as IXUITweenTool);
		}

		// Token: 0x0600AA50 RID: 43600 RVA: 0x001E732E File Offset: 0x001E552E
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_RankBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnRankBtnClick));
		}

		// Token: 0x0600AA51 RID: 43601 RVA: 0x001E7350 File Offset: 0x001E5550
		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._RefreshDataTimerID);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._AutoCloseTweenTimerID);
			this.m_VS.SetTexturePath(XSingleton<XGlobalConfig>.singleton.GetValue("BigMeleeVSTex"));
			this.m_VSLabel.SetText(XSingleton<XStringTable>.singleton.GetString("BIG_MELEE_LABEL"));
			float interval = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("BigMeleeVSTime"));
			this._AutoCloseTweenTimerID = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this.CloseVS), null);
			this.AutoRefresh(null);
			this.InitShow();
			this.RefreshStage();
			XSingleton<XDebug>.singleton.AddGreenLog("OnShow", null, null, null, null, null);
		}

		// Token: 0x0600AA52 RID: 43602 RVA: 0x001E741C File Offset: 0x001E561C
		public void ShieldMiniMapPlayer()
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler != null;
			if (flag)
			{
				for (int i = 0; i < this.doc.userIdToRole.size; i++)
				{
					bool flag2 = this.doc.userIdToRole.BufferKeys[i] == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (!flag2)
					{
						DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.SetMiniMapElement(this.doc.userIdToRole.BufferKeys[i], "", 0, 0);
					}
				}
			}
		}

		// Token: 0x0600AA53 RID: 43603 RVA: 0x001E74B8 File Offset: 0x001E56B8
		public void RefreshStage()
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.uiBehaviour != null && DlgBase<BattleMain, BattleMainBehaviour>.singleton.uiBehaviour.m_SkyAreanStage != null;
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.uiBehaviour.m_SkyAreanStage.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("BIG_MELEE_STAGE"), this.doc.Round.ToString()));
			}
		}

		// Token: 0x0600AA54 RID: 43604 RVA: 0x001E7530 File Offset: 0x001E5730
		public override void OnUpdate()
		{
			base.OnUpdate();
			this._ReviveCounter.Update();
			this._TimeCounter.Update();
			float leftTime = DlgBase<BattleMain, BattleMainBehaviour>.singleton.GetLeftTime();
			this.EndTip((int)leftTime);
		}

		// Token: 0x0600AA55 RID: 43605 RVA: 0x001E7571 File Offset: 0x001E5771
		public void CloseVS(object param)
		{
			this.m_VS.SetTexturePath("");
			this.m_VSLabel.SetText("");
		}

		// Token: 0x0600AA56 RID: 43606 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600AA57 RID: 43607 RVA: 0x001E7598 File Offset: 0x001E5798
		public override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._RefreshDataTimerID);
			this._RefreshDataTimerID = 0U;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._AutoCloseTweenTimerID);
			this._AutoCloseTweenTimerID = 0U;
			this.doc.battleHandler = null;
			base.OnUnload();
		}

		// Token: 0x0600AA58 RID: 43608 RVA: 0x001E75EC File Offset: 0x001E57EC
		private void AutoRefresh(object param)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				XBigMeleeEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XBigMeleeEntranceDocument>(XBigMeleeEntranceDocument.uuID);
				specificDocument.ReqRankData(XBigMeleeBattleDocument.BATTLE_SHOW_RANK);
				this._RefreshDataTimerID = XSingleton<XTimerMgr>.singleton.SetTimer(2f, new XTimerMgr.ElapsedEventHandler(this.AutoRefresh), null);
			}
		}

		// Token: 0x0600AA59 RID: 43609 RVA: 0x001E7640 File Offset: 0x001E5840
		public void InitShow()
		{
			this.m_MyRank.SetText(XSingleton<XStringTable>.singleton.GetString("NoRank"));
			this.m_MyName.SetText("");
			this.m_MyValue.SetText("0");
			this.PointStage = 0;
			this.RefreshPointStage(0UL);
			this.m_Time.gameObject.SetActive(false);
			DlgBase<BattleMain, BattleMainBehaviour>.singleton.HideLeftTime();
			this.m_RankPool.ReturnAll(false);
			for (int i = 0; i < this.isEndTimeTip.Length; i++)
			{
				this.isEndTimeTip[i] = false;
			}
		}

		// Token: 0x0600AA5A RID: 43610 RVA: 0x001E76E8 File Offset: 0x001E58E8
		public void RefreshRank()
		{
			List<XBaseRankInfo> rankList = XBigMeleeEntranceDocument.Doc.RankList.rankList;
			XBaseRankInfo myRankInfo = XBigMeleeEntranceDocument.Doc.RankList.myRankInfo;
			uint num = myRankInfo.rank + 1U;
			bool flag = myRankInfo != null;
			if (flag)
			{
				bool flag2 = num == 0U || (ulong)num > (ulong)((long)XBigMeleeEntranceDocument.MAX_RANK);
				if (flag2)
				{
					this.m_MyRank.SetText(XSingleton<XStringTable>.singleton.GetString("NoRank"));
				}
				else
				{
					this.m_MyRank.SetText(num.ToString());
				}
				this.m_MyName.SetText(myRankInfo.name);
				this.m_MyValue.SetText(myRankInfo.value.ToString());
				this.RefreshPointStage(myRankInfo.value);
			}
			this.m_RankPool.FakeReturnAll();
			int num2 = 0;
			while (num2 < rankList.Count && num2 < XBigMeleeBattleDocument.BATTLE_SHOW_RANK)
			{
				GameObject gameObject = this.m_RankPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)num2 * this.m_RankPool.TplHeight), 0f) + this.m_RankPool.TplPos;
				IXUILabel ixuilabel = gameObject.transform.Find("Rank").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = gameObject.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = gameObject.transform.Find("Value").GetComponent("XUILabel") as IXUILabel;
				XBigMeleeRankInfo xbigMeleeRankInfo = rankList[num2] as XBigMeleeRankInfo;
				ixuilabel.SetText((xbigMeleeRankInfo.rank + 1U).ToString());
				ixuilabel2.SetText(xbigMeleeRankInfo.name);
				ixuilabel3.SetText(xbigMeleeRankInfo.value.ToString());
				num2++;
			}
			this.m_RankPool.ActualReturnAll(false);
		}

		// Token: 0x0600AA5B RID: 43611 RVA: 0x001E78EC File Offset: 0x001E5AEC
		private void RefreshPointStage(ulong value)
		{
			while (this.PointStage < this.PointRewardList.Count && value >= (ulong)((long)this.PointRewardList[this.PointStage].point))
			{
				this.PointStage++;
			}
			bool flag = this.PointStage < this.PointRewardList.Count;
			if (flag)
			{
				this.m_PointRewardTips.SetText(string.Format(XStringDefineProxy.GetString("BIG_MELEE_POINT_STAGE"), this.PointRewardList[this.PointStage].point.ToString()));
			}
			else
			{
				this.m_PointRewardTips.SetText(XStringDefineProxy.GetString("BIG_MELEE_MAX_POINT_STAGE"));
			}
		}

		// Token: 0x0600AA5C RID: 43612 RVA: 0x001E79AC File Offset: 0x001E5BAC
		public void RefreshStatusTime(uint type, uint time)
		{
			bool flag = type == 1U;
			if (flag)
			{
				bool flag2 = this.m_Time.IsVisible();
				if (flag2)
				{
					this.m_Time.gameObject.SetActive(false);
				}
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLeftTime(time, -1);
			}
			else
			{
				bool flag3 = type == 2U;
				if (flag3)
				{
					bool flag4 = !this.m_Time.IsVisible();
					if (flag4)
					{
						this.m_Time.gameObject.SetActive(true);
					}
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.HideLeftTime();
					bool flag5 = (ulong)this.doc.Round == (ulong)((long)int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("BigMeleeMaxGames")));
					if (flag5)
					{
						this.m_Time.SetText(XSingleton<XStringTable>.singleton.GetString("BIG_MELEE_WAIT_REWARD"));
					}
					else
					{
						this._TimeCounter.SetLeftTime(time, -1);
						this._TimeCounter.SetFinishEventHandler(new TimeOverFinishEventHandler(this._OnLeftTimeOver), null);
						this._TimeCounter.SetFormatString(XSingleton<XStringTable>.singleton.GetString("BIG_MELEE_NEXT_BATTLE_TIME"));
					}
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.EnemyInfoHandler.SetVisible(false);
				}
			}
		}

		// Token: 0x0600AA5D RID: 43613 RVA: 0x001E7AD2 File Offset: 0x001E5CD2
		private void _OnLeftTimeOver(object o)
		{
			this.m_Time.SetText(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_MATCHING"));
		}

		// Token: 0x0600AA5E RID: 43614 RVA: 0x001E7AF0 File Offset: 0x001E5CF0
		public void SetReviveTime(uint time)
		{
			this._ReviveCounter.SetLeftTime(time + 0.5f, -1);
		}

		// Token: 0x0600AA5F RID: 43615 RVA: 0x001E7B0C File Offset: 0x001E5D0C
		private bool _OnRankBtnClick(IXUIButton btn)
		{
			this.m_Tween.PlayTween(true, -1f);
			return true;
		}

		// Token: 0x0600AA60 RID: 43616 RVA: 0x001E7B34 File Offset: 0x001E5D34
		public void EndTip(int time)
		{
			bool flag = time >= 7 || time <= 0;
			if (!flag)
			{
				int num = time - 1;
				bool flag2 = this.isEndTimeTip[num];
				if (!flag2)
				{
					this.isEndTimeTip[num] = true;
					bool flag3 = time == 6;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("BIG_MELEE_END_TIP"), "fece00");
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(time.ToString(), "fece00");
					}
				}
			}
		}

		// Token: 0x0600AA61 RID: 43617 RVA: 0x001E7BAC File Offset: 0x001E5DAC
		public void SetGetPointAnimation(uint point, uint posxz)
		{
			bool flag = Time.time - this.LastTime < 2f;
			if (flag)
			{
				point += this.LastPoint;
			}
			this.LastPoint = point;
			this.LastTime = Time.time;
			this.m_Point.SetText(string.Format("ef+{0}", point));
			this.m_PlayTween.PlayTween(true, -1f);
			XSingleton<XDebug>.singleton.AddGreenLog("addpoint:" + point, null, null, null, null, null);
		}

		// Token: 0x04003F0C RID: 16140
		private XBigMeleeBattleDocument doc = null;

		// Token: 0x04003F0D RID: 16141
		private uint _RefreshDataTimerID = 0U;

		// Token: 0x04003F0E RID: 16142
		private uint _AutoCloseTweenTimerID = 0U;

		// Token: 0x04003F0F RID: 16143
		private bool[] isEndTimeTip = new bool[6];

		// Token: 0x04003F10 RID: 16144
		private List<BigMeleePointReward.RowData> PointRewardList = new List<BigMeleePointReward.RowData>();

		// Token: 0x04003F11 RID: 16145
		private int PointStage;

		// Token: 0x04003F12 RID: 16146
		private XLeftTimeCounter _ReviveCounter;

		// Token: 0x04003F13 RID: 16147
		private XLeftTimeCounter _TimeCounter;

		// Token: 0x04003F14 RID: 16148
		private IXUITexture m_VS;

		// Token: 0x04003F15 RID: 16149
		private IXUILabel m_VSLabel;

		// Token: 0x04003F16 RID: 16150
		private IXUILabel m_MyRank;

		// Token: 0x04003F17 RID: 16151
		private IXUILabel m_MyName;

		// Token: 0x04003F18 RID: 16152
		private IXUILabel m_MyValue;

		// Token: 0x04003F19 RID: 16153
		private IXUIButton m_RankBtn;

		// Token: 0x04003F1A RID: 16154
		private IXUITweenTool m_Tween;

		// Token: 0x04003F1B RID: 16155
		private IXUILabel m_ReviveTime;

		// Token: 0x04003F1C RID: 16156
		private IXUILabel m_Time;

		// Token: 0x04003F1D RID: 16157
		private IXUILabel m_PointRewardTips;

		// Token: 0x04003F1E RID: 16158
		private IXUILabel m_Point;

		// Token: 0x04003F1F RID: 16159
		private IXUITweenTool m_PlayTween;

		// Token: 0x04003F20 RID: 16160
		private XUIPool m_RankPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003F21 RID: 16161
		private float LastTime;

		// Token: 0x04003F22 RID: 16162
		private uint LastPoint;
	}
}
