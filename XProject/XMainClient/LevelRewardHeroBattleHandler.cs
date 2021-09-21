using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BA0 RID: 2976
	internal class LevelRewardHeroBattleHandler : DlgHandlerBase
	{
		// Token: 0x17003045 RID: 12357
		// (get) Token: 0x0600AAC2 RID: 43714 RVA: 0x001EC348 File Offset: 0x001EA548
		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardHeroBattleHandler";
			}
		}

		// Token: 0x0600AAC3 RID: 43715 RVA: 0x001EC360 File Offset: 0x001EA560
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this._heroDoc = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			this.m_Win = base.PanelObject.transform.Find("Bg/Result/win").gameObject;
			this.m_Lose = base.PanelObject.transform.Find("Bg/Result/lose").gameObject;
			this.m_Draw = base.PanelObject.transform.Find("Bg/Result/draw").gameObject;
			this.m_Time = (base.PanelObject.transform.Find("Bg/Board/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_BackBtn = (base.PanelObject.transform.Find("Bg/button/Continue").GetComponent("XUIButton") as IXUIButton);
			this.m_ShareBtn = (base.PanelObject.transform.Find("Bg/button/ShareBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_BattleDataBtn = (base.PanelObject.transform.Find("Bg/button/BattleData").GetComponent("XUIButton") as IXUIButton);
			this.m_BattleDataCloseBtn = (base.PanelObject.transform.Find("Bg/PVPDataFrame/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_PVPDataFrame = base.PanelObject.transform.Find("Bg/PVPDataFrame").gameObject;
			Transform transform = this.m_PVPDataFrame.transform.Find("Panel/MemberTpl");
			this.m_BattleDataPool.SetupPool(transform.parent.gameObject, transform.gameObject, 8U, false);
			Transform transform2 = base.PanelObject.transform.Find("Bg/Board/team1/Panel/MiniIconTpl");
			this.m_IconPool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 15U, false);
			transform2 = base.PanelObject.transform.Find("Bg/Board/team1/Panel/PlayerTpl");
			this.m_PlayerPool_L.SetupPool(transform2.parent.gameObject, transform2.gameObject, 8U, false);
			transform2 = base.PanelObject.transform.Find("Bg/Board/team2/Panel/PlayerTpl");
			this.m_PlayerPool_R.SetupPool(transform2.parent.gameObject, transform2.gameObject, 8U, false);
			transform2 = base.PanelObject.transform.Find("Bg/button/Reward/ItemTpl");
			this.m_ItemPool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 24U, false);
		}

		// Token: 0x0600AAC4 RID: 43716 RVA: 0x001EC5F4 File Offset: 0x001EA7F4
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BackBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBackBtnClick));
			this.m_BattleDataBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBattleDataBtnClick));
			this.m_BattleDataCloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBattleDataCloseBtnClick));
			this.m_ShareBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShareBtnClick));
		}

		// Token: 0x0600AAC5 RID: 43717 RVA: 0x001EC66C File Offset: 0x001EA86C
		private bool OnBackBtnClick(IXUIButton btn)
		{
			bool flag = Time.time - this.m_leaveTime < 5f;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.m_leaveTime = Time.time;
				XSingleton<XScene>.singleton.ReqLeaveScene();
				result = true;
			}
			return result;
		}

		// Token: 0x0600AAC6 RID: 43718 RVA: 0x001EC6B0 File Offset: 0x001EA8B0
		private bool OnBattleDataBtnClick(IXUIButton btn)
		{
			this.m_PVPDataFrame.SetActive(true);
			return true;
		}

		// Token: 0x0600AAC7 RID: 43719 RVA: 0x001EC6D0 File Offset: 0x001EA8D0
		private bool OnBattleDataCloseBtnClick(IXUIButton btn)
		{
			this.m_PVPDataFrame.SetActive(false);
			return true;
		}

		// Token: 0x0600AAC8 RID: 43720 RVA: 0x001EC6F0 File Offset: 0x001EA8F0
		private bool OnShareBtnClick(IXUIButton btn)
		{
			XSingleton<PDatabase>.singleton.shareCallbackType = ShareCallBackType.WeekShare;
			XSingleton<XScreenShotMgr>.singleton.StartExternalScreenShotView(null);
			XSingleton<XScreenShotMgr>.singleton.SendStatisticToServer(ShareOpType.Share, DragonShareType.ShowGlory);
			return true;
		}

		// Token: 0x0600AAC9 RID: 43721 RVA: 0x0019F00C File Offset: 0x0019D20C
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600AACA RID: 43722 RVA: 0x001EC727 File Offset: 0x001EA927
		public void PlayCutScene()
		{
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this._heroDoc = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			this._heroDoc.StartMvpCutScene();
		}

		// Token: 0x0600AACB RID: 43723 RVA: 0x001EC758 File Offset: 0x001EA958
		public void ShowUI()
		{
			DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.SetVisible(true, true);
			base.SetVisible(true);
			this.SetupBattleDataUI();
			this.m_Win.SetActive(false);
			this.m_Lose.SetActive(false);
			this.m_Draw.SetActive(false);
			switch (this._doc.HeroData.Result)
			{
			case HeroBattleOver.HeroBattleOver_Win:
				this.m_Win.SetActive(true);
				break;
			case HeroBattleOver.HeroBattleOver_Lose:
				this.m_Lose.SetActive(true);
				break;
			case HeroBattleOver.HeroBattleOver_Draw:
				this.m_Draw.SetActive(true);
				break;
			}
			this.m_PlayerPool_L.ReturnAll(false);
			this.m_PlayerPool_R.ReturnAll(false);
			this.m_IconPool.ReturnAll(false);
			this._killMax = this._doc.HeroData.KillMax;
			this._DeathMin = this._doc.HeroData.DeathMin;
			this._AssistsMax = this._doc.HeroData.AssitMax;
			this._DamageMax = this._doc.HeroData.DamageMax;
			this._BeHitMax = this._doc.HeroData.BeHitMax;
			this.m_Time.SetText(XSingleton<UiUtility>.singleton.TimeFormatString(this._doc.LevelFinishTime, 2, 3, 4, false, true));
			for (int i = 0; i < this._doc.HeroData.Team1Data.Count; i++)
			{
				this.SetupData(this.m_PlayerPool_L.FetchGameObject(false), this._doc.HeroData.Team1Data[i], i, true);
			}
			for (int j = 0; j < this._doc.HeroData.Team2Data.Count; j++)
			{
				this.SetupData(this.m_PlayerPool_R.FetchGameObject(false), this._doc.HeroData.Team2Data[j], j, false);
			}
			this.m_ItemPool.ReturnAll(false);
			int num = this._doc.HeroData.DayJoinReward.Count + this._doc.HeroData.WinReward.Count;
			Vector3 vector = this.m_ItemPool.TplPos;
			for (int k = 0; k < this._doc.HeroData.DayJoinReward.Count; k++)
			{
				GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
				IXUILabel ixuilabel = gameObject.transform.Find("Day").GetComponent("XUILabel") as IXUILabel;
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)this._doc.HeroData.DayJoinReward[k].itemID, (int)this._doc.HeroData.DayJoinReward[k].itemCount, false);
				ixuilabel.Alpha = 1f;
				gameObject.transform.localPosition = vector;
				vector += new Vector3((float)this.m_ItemPool.TplWidth, 0f);
			}
			for (int l = 0; l < this._doc.HeroData.WinReward.Count; l++)
			{
				GameObject gameObject2 = this.m_ItemPool.FetchGameObject(false);
				IXUILabel ixuilabel2 = gameObject2.transform.Find("Day").GetComponent("XUILabel") as IXUILabel;
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, (int)this._doc.HeroData.WinReward[l].itemID, (int)this._doc.HeroData.WinReward[l].itemCount, false);
				ixuilabel2.Alpha = 0f;
				gameObject2.transform.localPosition = vector;
				vector += new Vector3((float)this.m_ItemPool.TplWidth, 0f);
			}
		}

		// Token: 0x0600AACC RID: 43724 RVA: 0x001ECB74 File Offset: 0x001EAD74
		private void SetupData(GameObject go, XLevelRewardDocument.PVPRoleInfo data, int index, bool isLeft)
		{
			Vector3 tplPos = this.m_PlayerPool_L.TplPos;
			go.transform.localScale = Vector3.one;
			go.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(index * this.m_PlayerPool_L.TplHeight));
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag)
			{
				GameObject gameObject = go.transform.Find("me").gameObject;
				gameObject.SetActive(data.uID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID);
			}
			IXUILabel ixuilabel = go.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(data.Name);
			IXUISprite ixuisprite = go.transform.Find("Military").GetComponent("XUISprite") as IXUISprite;
			XMilitaryRankDocument specificDocument = XDocuments.GetSpecificDocument<XMilitaryRankDocument>(XMilitaryRankDocument.uuID);
			ixuisprite.spriteName = XMilitaryRankDocument.GetMilitaryIcon(data.militaryRank);
			IXUILabel ixuilabel2 = go.transform.Find("kill").GetComponent("XUILabel") as IXUILabel;
			ixuilabel2.SetText(data.KillCount.ToString());
			bool flag2 = data.KillCount == this._killMax;
			if (flag2)
			{
				ixuilabel2.SetColor(new Color32(byte.MaxValue, 145, 69, byte.MaxValue));
			}
			IXUILabel ixuilabel3 = go.transform.Find("dead").GetComponent("XUILabel") as IXUILabel;
			ixuilabel3.SetText(data.DeathCount.ToString());
			bool flag3 = (ulong)data.DeathCount == (ulong)((long)this._DeathMin);
			if (flag3)
			{
				ixuilabel3.SetColor(new Color32(byte.MaxValue, 145, 69, byte.MaxValue));
			}
			IXUILabel ixuilabel4 = go.transform.Find("assists").GetComponent("XUILabel") as IXUILabel;
			ixuilabel4.SetText(data.AssitCount.ToString());
			bool flag4 = (ulong)data.AssitCount == (ulong)((long)this._AssistsMax);
			if (flag4)
			{
				ixuilabel4.SetColor(new Color32(byte.MaxValue, 145, 69, byte.MaxValue));
			}
			Transform ts = go.transform.Find("Frame");
			this.SetupIconList(ts, data, isLeft);
			IXUISprite ixuisprite2 = go.transform.Find("Avatar").GetComponent("XUISprite") as IXUISprite;
			GameObject gameObject2 = go.transform.Find("UnSelect").gameObject;
			uint num = 0U;
			this._heroDoc.heroIDIndex.TryGetValue(data.uID, out num);
			bool flag5 = num == 0U;
			if (flag5)
			{
				ixuisprite2.SetVisible(false);
				gameObject2.SetActive(true);
			}
			else
			{
				ixuisprite2.SetVisible(true);
				gameObject2.SetActive(false);
				string strAtlas;
				string strSprite;
				XHeroBattleDocument.GetIconByHeroID(num, out strAtlas, out strSprite);
				ixuisprite2.SetSprite(strSprite, strAtlas, false);
			}
			IXUILabel ixuilabel5 = go.transform.Find("Level").GetComponent("XUILabel") as IXUILabel;
			ixuilabel5.SetText(data.Level.ToString());
			GameObject gameObject3 = go.transform.Find("MVP").gameObject;
			gameObject3.SetActive(data.IsMvp);
			IXUILabel ixuilabel6 = go.transform.Find("Score").GetComponent("XUILabel") as IXUILabel;
			ixuilabel6.SetText(data.Kda.ToString("0.0"));
			bool isMvp = data.IsMvp;
			if (isMvp)
			{
				ixuilabel6.gameObject.transform.localPosition = new Vector3((float)(isLeft ? -240 : 240), -18f);
			}
			else
			{
				ixuilabel6.gameObject.transform.localPosition = new Vector3((float)(isLeft ? -240 : 240), 4f);
			}
			IXUISprite ixuisprite3 = go.transform.Find("Report").GetComponent("XUISprite") as IXUISprite;
			bool flag6 = data.uID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			if (flag6)
			{
				ixuisprite3.SetVisible(false);
			}
			else
			{
				ixuisprite3.SetVisible(true);
				ixuisprite3.ID = (ulong)((long)(index * 2 + (isLeft ? 1 : 0)));
				ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnReportBtnClick));
			}
		}

		// Token: 0x0600AACD RID: 43725 RVA: 0x001ED004 File Offset: 0x001EB204
		private void OnReportBtnClick(IXUISprite iSp)
		{
			bool flag = !DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				bool flag2 = iSp.ID % 2UL == 1UL;
				int num = (int)iSp.ID / 2;
				bool flag3 = flag2;
				if (flag3)
				{
					bool flag4 = num < this._doc.HeroData.Team1Data.Count;
					if (flag4)
					{
						DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowReport(this._doc.HeroData.Team1Data[num].uID, this._doc.HeroData.Team1Data[num].Name, iSp);
					}
				}
				else
				{
					bool flag5 = num < this._doc.HeroData.Team2Data.Count;
					if (flag5)
					{
						DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowReport(this._doc.HeroData.Team2Data[num].uID, this._doc.HeroData.Team2Data[num].Name, iSp);
					}
				}
			}
		}

		// Token: 0x0600AACE RID: 43726 RVA: 0x001ED10C File Offset: 0x001EB30C
		private void SetupIconList(Transform ts, XLevelRewardDocument.PVPRoleInfo data, bool isLeft)
		{
			int num = 0;
			bool flag = data.MaxKillCount > 2;
			if (flag)
			{
				int maxKillCount = data.MaxKillCount;
				string iconName;
				if (maxKillCount != 3)
				{
					if (maxKillCount != 4)
					{
						iconName = "ic_pf5";
					}
					else
					{
						iconName = "ic_pf4";
					}
				}
				else
				{
					iconName = "ic_pf3";
				}
				this.AddIcon(ts, iconName, num, isLeft);
				num++;
			}
			bool flag2 = data.KillCount == this._killMax;
			if (flag2)
			{
				string iconName = "ic_pf1";
				this.AddIcon(ts, iconName, num, isLeft);
				num++;
			}
			bool flag3 = (ulong)data.AssitCount == (ulong)((long)this._AssistsMax);
			if (flag3)
			{
				string iconName = "ic_pf6";
				this.AddIcon(ts, iconName, num, isLeft);
				num++;
			}
			bool flag4 = data.BeHit == this._BeHitMax;
			if (flag4)
			{
				string iconName = "ic_pf2";
				this.AddIcon(ts, iconName, num, isLeft);
				num++;
			}
			bool flag5 = data.Damage == this._DamageMax;
			if (flag5)
			{
				string iconName = "ic_pf0";
				this.AddIcon(ts, iconName, num, isLeft);
				num++;
			}
		}

		// Token: 0x0600AACF RID: 43727 RVA: 0x001ED21C File Offset: 0x001EB41C
		private void AddIcon(Transform ts, string iconName, int index, bool isLeft)
		{
			GameObject gameObject = this.m_IconPool.FetchGameObject(false);
			gameObject.transform.parent = ts;
			int num = isLeft ? 1 : -1;
			gameObject.transform.localPosition = new Vector3((float)(index * num * this.m_IconPool.TplWidth), 0f);
			IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.spriteName = iconName;
		}

		// Token: 0x0600AAD0 RID: 43728 RVA: 0x001ED28C File Offset: 0x001EB48C
		private void SetupBattleDataUI()
		{
			this.m_PVPDataFrame.SetActive(false);
			IXUILabel ixuilabel = this.m_PVPDataFrame.gameObject.transform.Find("Time").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(string.Format("{0} {1}", XStringDefineProxy.GetString("LEVEL_FINISH_TIME"), XSingleton<UiUtility>.singleton.TimeFormatString(this._doc.LevelFinishTime, 2, 3, 4, false, true)));
			this.m_BattleDataPool.ReturnAll(false);
			Vector3 vector = this.m_BattleDataPool.TplPos;
			for (int i = 0; i < this._doc.HeroData.Team1Data.Count; i++)
			{
				GameObject gameObject = this.m_BattleDataPool.FetchGameObject(false);
				this.SetupBattleDataDetailUI(gameObject, this._doc.HeroData.Team1Data[i], true);
				gameObject.transform.localPosition = vector;
				vector += new Vector3(0f, (float)(-(float)this.m_BattleDataPool.TplHeight));
			}
			for (int j = 0; j < this._doc.HeroData.Team2Data.Count; j++)
			{
				GameObject gameObject2 = this.m_BattleDataPool.FetchGameObject(false);
				this.SetupBattleDataDetailUI(gameObject2, this._doc.HeroData.Team2Data[j], false);
				gameObject2.transform.localPosition = vector;
				vector += new Vector3(0f, (float)(-(float)this.m_BattleDataPool.TplHeight));
			}
		}

		// Token: 0x0600AAD1 RID: 43729 RVA: 0x001ED428 File Offset: 0x001EB628
		private void SetupBattleDataDetailUI(GameObject go, XLevelRewardDocument.PVPRoleInfo data, bool isteam1)
		{
			IXUISprite ixuisprite = go.transform.Find("Detail/Avatar").GetComponent("XUISprite") as IXUISprite;
			GameObject gameObject = go.transform.Find("Detail/UnSelect").gameObject;
			IXUILabel ixuilabel = go.transform.Find("Detail/Name").GetComponent("XUILabel") as IXUILabel;
			Transform transform = go.transform.Find("Detail/Team1");
			Transform transform2 = go.transform.Find("Detail/Team2");
			GameObject gameObject2 = go.transform.Find("Detail/Leader").gameObject;
			IXUILabel ixuilabel2 = go.transform.Find("KillTotal").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = go.transform.Find("MaxKill").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel4 = go.transform.Find("DeathCount").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel5 = go.transform.Find("DamageTotal").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel6 = go.transform.Find("HealTotal").GetComponent("XUILabel") as IXUILabel;
			uint num = 0U;
			this._heroDoc.heroIDIndex.TryGetValue(data.uID, out num);
			bool flag = num == 0U;
			if (flag)
			{
				ixuisprite.SetVisible(false);
				gameObject.SetActive(true);
			}
			else
			{
				ixuisprite.SetVisible(true);
				gameObject.SetActive(false);
				string strAtlas;
				string strSprite;
				XHeroBattleDocument.GetIconByHeroID(num, out strAtlas, out strSprite);
				ixuisprite.SetSprite(strSprite, strAtlas, false);
			}
			ixuilabel.SetText(data.Name);
			transform.gameObject.SetActive(isteam1);
			transform2.gameObject.SetActive(!isteam1);
			gameObject2.SetActive(data.uID == this._doc.HeroData.MvpData.uID);
			ixuilabel2.SetText(data.KillCount.ToString());
			ixuilabel3.SetText(data.MaxKillCount.ToString());
			ixuilabel4.SetText(data.DeathCount.ToString());
			ixuilabel5.SetText(XSingleton<UiUtility>.singleton.NumberFormat(data.Damage));
			ixuilabel6.SetText(XSingleton<UiUtility>.singleton.NumberFormat(data.Heal));
		}

		// Token: 0x04003F90 RID: 16272
		private XLevelRewardDocument _doc = null;

		// Token: 0x04003F91 RID: 16273
		private XHeroBattleDocument _heroDoc = null;

		// Token: 0x04003F92 RID: 16274
		private XUIPool m_PlayerPool_L = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003F93 RID: 16275
		private XUIPool m_PlayerPool_R = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003F94 RID: 16276
		private XUIPool m_IconPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003F95 RID: 16277
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003F96 RID: 16278
		private XUIPool m_BattleDataPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003F97 RID: 16279
		private GameObject m_Win;

		// Token: 0x04003F98 RID: 16280
		private GameObject m_Lose;

		// Token: 0x04003F99 RID: 16281
		private GameObject m_Draw;

		// Token: 0x04003F9A RID: 16282
		private IXUIButton m_BackBtn;

		// Token: 0x04003F9B RID: 16283
		private IXUIButton m_BattleDataBtn;

		// Token: 0x04003F9C RID: 16284
		private IXUIButton m_BattleDataCloseBtn;

		// Token: 0x04003F9D RID: 16285
		private IXUILabel m_Time;

		// Token: 0x04003F9E RID: 16286
		private IXUIButton m_ShareBtn;

		// Token: 0x04003F9F RID: 16287
		public GameObject m_PVPDataFrame;

		// Token: 0x04003FA0 RID: 16288
		private float m_leaveTime;

		// Token: 0x04003FA1 RID: 16289
		private int _killMax;

		// Token: 0x04003FA2 RID: 16290
		private int _DeathMin;

		// Token: 0x04003FA3 RID: 16291
		private int _AssistsMax;

		// Token: 0x04003FA4 RID: 16292
		private ulong _DamageMax;

		// Token: 0x04003FA5 RID: 16293
		private uint _BeHitMax;
	}
}
