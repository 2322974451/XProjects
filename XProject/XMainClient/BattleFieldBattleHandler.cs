using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A2C RID: 2604
	internal class BattleFieldBattleHandler : DlgHandlerBase
	{
		// Token: 0x17002ECF RID: 11983
		// (get) Token: 0x06009EE9 RID: 40681 RVA: 0x001A3ECC File Offset: 0x001A20CC
		protected override string FileName
		{
			get
			{
				return "Battle/BattleField";
			}
		}

		// Token: 0x06009EEA RID: 40682 RVA: 0x001A3EE4 File Offset: 0x001A20E4
		protected override void Init()
		{
			base.Init();
			XBattleFieldBattleDocument.Doc.battleHandler = this;
			this.m_ReviveTime = (base.transform.FindChild("ReviveTime").GetComponent("XUILabel") as IXUILabel);
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
		}

		// Token: 0x06009EEB RID: 40683 RVA: 0x001A403D File Offset: 0x001A223D
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_RankBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnRankBtnClick));
		}

		// Token: 0x06009EEC RID: 40684 RVA: 0x001A405F File Offset: 0x001A225F
		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._RefreshRankTimerID);
			this.AutoRefresh(null);
			this.InitShow();
		}

		// Token: 0x06009EED RID: 40685 RVA: 0x001A408C File Offset: 0x001A228C
		public override void OnUpdate()
		{
			base.OnUpdate();
			this._ReviveCounter.Update();
			float leftTime = DlgBase<BattleMain, BattleMainBehaviour>.singleton.GetLeftTime();
			this.EndTip((int)leftTime);
		}

		// Token: 0x06009EEE RID: 40686 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x06009EEF RID: 40687 RVA: 0x001A40C1 File Offset: 0x001A22C1
		public override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._RefreshRankTimerID);
			this._RefreshRankTimerID = 0U;
			XBattleFieldBattleDocument.Doc.battleHandler = null;
			base.OnUnload();
		}

		// Token: 0x06009EF0 RID: 40688 RVA: 0x001A40F0 File Offset: 0x001A22F0
		private void AutoRefresh(object param)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				XBattleFieldBattleDocument.Doc.ReqRankData();
				this._RefreshRankTimerID = XSingleton<XTimerMgr>.singleton.SetTimer(2f, new XTimerMgr.ElapsedEventHandler(this.AutoRefresh), null);
			}
		}

		// Token: 0x06009EF1 RID: 40689 RVA: 0x001A4138 File Offset: 0x001A2338
		public void InitShow()
		{
			this.m_MyRank.SetText(XSingleton<XStringTable>.singleton.GetString("NoRank"));
			this.m_MyName.SetText("");
			this.m_MyValue.SetText("0");
			this.PointStage = 0;
			this.RefreshPointStage(0UL);
			DlgBase<BattleMain, BattleMainBehaviour>.singleton.HideLeftTime();
			this.m_RankPool.ReturnAll(false);
			for (int i = 0; i < this.isEndTimeTip.Length; i++)
			{
				this.isEndTimeTip[i] = false;
			}
			this.PointRewardList = XBattleFieldEntranceDocument.Doc.GetPointRewardList();
			for (int j = this.PointRewardList.Count - 1; j >= 0; j--)
			{
				BattleFieldPointReward.RowData curPointRewardList = XBattleFieldEntranceDocument.Doc.GetCurPointRewardList(this.PointRewardList[j].id);
				uint pointRewardGetCount = XBattleFieldEntranceDocument.Doc.GetPointRewardGetCount(this.PointRewardList[j].id);
				bool flag = pointRewardGetCount == curPointRewardList.count;
				if (flag)
				{
					this.PointRewardList.RemoveAt(j);
				}
			}
		}

		// Token: 0x06009EF2 RID: 40690 RVA: 0x001A4254 File Offset: 0x001A2454
		public void RefreshRank(List<BattleFieldRank> data)
		{
			int num = -1;
			for (int i = 0; i < data.Count; i++)
			{
				bool flag = data[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					num = i;
					break;
				}
			}
			bool flag2 = num != -1;
			if (flag2)
			{
				BattleFieldRank battleFieldRank = data[num];
				this.m_MyRank.SetText((num + 1).ToString());
				this.m_MyName.SetText(battleFieldRank.name);
				this.m_MyValue.SetText(battleFieldRank.point.ToString());
				this.RefreshPointStage((ulong)battleFieldRank.point);
			}
			this.m_RankPool.FakeReturnAll();
			int num2 = 0;
			while (num2 < data.Count && num2 < XBigMeleeBattleDocument.BATTLE_SHOW_RANK)
			{
				GameObject gameObject = this.m_RankPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)num2 * this.m_RankPool.TplHeight), 0f) + this.m_RankPool.TplPos;
				IXUILabel ixuilabel = gameObject.transform.Find("Rank").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = gameObject.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = gameObject.transform.Find("Value").GetComponent("XUILabel") as IXUILabel;
				BattleFieldRank battleFieldRank2 = data[num2];
				ixuilabel.SetText((num2 + 1).ToString());
				ixuilabel2.SetText(battleFieldRank2.name);
				ixuilabel3.SetText(battleFieldRank2.point.ToString());
				num2++;
			}
			this.m_RankPool.ActualReturnAll(false);
		}

		// Token: 0x06009EF3 RID: 40691 RVA: 0x001A4450 File Offset: 0x001A2650
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

		// Token: 0x06009EF4 RID: 40692 RVA: 0x001A4510 File Offset: 0x001A2710
		public void SetReviveTime(uint time)
		{
			this._ReviveCounter.SetLeftTime(time + 0.5f, -1);
		}

		// Token: 0x06009EF5 RID: 40693 RVA: 0x001A452C File Offset: 0x001A272C
		private bool _OnRankBtnClick(IXUIButton btn)
		{
			this.m_Tween.PlayTween(true, -1f);
			return true;
		}

		// Token: 0x06009EF6 RID: 40694 RVA: 0x001A4554 File Offset: 0x001A2754
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

		// Token: 0x0400389D RID: 14493
		private uint _RefreshRankTimerID = 0U;

		// Token: 0x0400389E RID: 14494
		private bool[] isEndTimeTip = new bool[6];

		// Token: 0x0400389F RID: 14495
		private List<BattleFieldPointReward.RowData> PointRewardList = new List<BattleFieldPointReward.RowData>();

		// Token: 0x040038A0 RID: 14496
		private int PointStage;

		// Token: 0x040038A1 RID: 14497
		private XLeftTimeCounter _ReviveCounter;

		// Token: 0x040038A2 RID: 14498
		private IXUILabel m_MyRank;

		// Token: 0x040038A3 RID: 14499
		private IXUILabel m_MyName;

		// Token: 0x040038A4 RID: 14500
		private IXUILabel m_MyValue;

		// Token: 0x040038A5 RID: 14501
		private IXUIButton m_RankBtn;

		// Token: 0x040038A6 RID: 14502
		private IXUITweenTool m_Tween;

		// Token: 0x040038A7 RID: 14503
		private IXUILabel m_ReviveTime;

		// Token: 0x040038A8 RID: 14504
		private IXUILabel m_PointRewardTips;

		// Token: 0x040038A9 RID: 14505
		private XUIPool m_RankPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
