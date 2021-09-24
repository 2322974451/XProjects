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

	internal class LevelRewardMobaBattleHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardMobaBattleHandler";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this._mobaDoc = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BackBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBackBtnClick));
			this.m_BattleDataBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBattleDataBtnClick));
			this.m_BattleDataCloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBattleDataCloseBtnClick));
			this.m_ShareBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShareBtnClick));
		}

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

		private bool OnBattleDataBtnClick(IXUIButton btn)
		{
			this.m_PVPDataFrame.SetActive(true);
			return true;
		}

		private bool OnBattleDataCloseBtnClick(IXUIButton btn)
		{
			this.m_PVPDataFrame.SetActive(false);
			return true;
		}

		private bool OnShareBtnClick(IXUIButton btn)
		{
			XSingleton<PDatabase>.singleton.shareCallbackType = ShareCallBackType.WeekShare;
			XSingleton<XScreenShotMgr>.singleton.SendStatisticToServer(ShareOpType.Share, DragonShareType.ShowGlory);
			XSingleton<XScreenShotMgr>.singleton.StartExternalScreenShotView(null);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		public void PlayCutScene()
		{
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this._mobaDoc = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
			bool flag = this._doc.MobaData.Result == HeroBattleOver.HeroBattleOver_Win;
			bool blueWin;
			if (flag)
			{
				blueWin = (this._mobaDoc.MyData.teamID == 11U);
			}
			else
			{
				blueWin = (this._mobaDoc.MyData.teamID == 12U);
			}
			this._mobaDoc.StartMvpCutScene(blueWin);
		}

		public void ShowUI()
		{
			DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.SetVisible(true, true);
			base.SetVisible(true);
			this.SetupBattleDataUI();
			this.m_Win.SetActive(false);
			this.m_Lose.SetActive(false);
			this.m_Draw.SetActive(false);
			switch (this._doc.MobaData.Result)
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
			this._killMax = this._doc.MobaData.KillMax;
			this._DeathMin = this._doc.MobaData.DeathMin;
			this._AssistsMax = this._doc.MobaData.AssitMax;
			this.m_Time.SetText(XSingleton<UiUtility>.singleton.TimeFormatString(this._doc.LevelFinishTime, 2, 3, 4, false, true));
			for (int i = 0; i < this._doc.MobaData.Team1Data.Count; i++)
			{
				this.SetupData(this.m_PlayerPool_L.FetchGameObject(false), this._doc.MobaData.Team1Data[i], i, true);
			}
			for (int j = 0; j < this._doc.MobaData.Team2Data.Count; j++)
			{
				this.SetupData(this.m_PlayerPool_R.FetchGameObject(false), this._doc.MobaData.Team2Data[j], j, false);
			}
			this.m_ItemPool.ReturnAll(false);
			int num = this._doc.MobaData.DayJoinReward.Count + this._doc.MobaData.WinReward.Count;
			Vector3 vector = this.m_ItemPool.TplPos;
			for (int k = 0; k < this._doc.MobaData.DayJoinReward.Count; k++)
			{
				GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
				IXUILabel ixuilabel = gameObject.transform.Find("Day").GetComponent("XUILabel") as IXUILabel;
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)this._doc.MobaData.DayJoinReward[k].itemID, (int)this._doc.MobaData.DayJoinReward[k].itemCount, false);
				ixuilabel.Alpha = 1f;
				gameObject.transform.localPosition = vector;
				vector += new Vector3((float)this.m_ItemPool.TplWidth, 0f);
			}
			for (int l = 0; l < this._doc.MobaData.WinReward.Count; l++)
			{
				GameObject gameObject2 = this.m_ItemPool.FetchGameObject(false);
				IXUILabel ixuilabel2 = gameObject2.transform.Find("Day").GetComponent("XUILabel") as IXUILabel;
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, (int)this._doc.MobaData.WinReward[l].itemID, (int)this._doc.MobaData.WinReward[l].itemCount, false);
				ixuilabel2.Alpha = 0f;
				gameObject2.transform.localPosition = vector;
				vector += new Vector3((float)this.m_ItemPool.TplWidth, 0f);
			}
		}

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
			uint heroIDByRoleID = this._mobaDoc.GetHeroIDByRoleID(data.uID);
			bool flag5 = heroIDByRoleID == 0U;
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
				XHeroBattleDocument.GetIconByHeroID(heroIDByRoleID, out strAtlas, out strSprite);
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
					bool flag4 = num < this._doc.MobaData.Team1Data.Count;
					if (flag4)
					{
						DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowReport(this._doc.MobaData.Team1Data[num].uID, this._doc.MobaData.Team1Data[num].Name, iSp);
					}
				}
				else
				{
					bool flag5 = num < this._doc.MobaData.Team2Data.Count;
					if (flag5)
					{
						DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowReport(this._doc.MobaData.Team2Data[num].uID, this._doc.MobaData.Team2Data[num].Name, iSp);
					}
				}
			}
		}

		private void SetupIconList(Transform ts, XLevelRewardDocument.PVPRoleInfo data, bool isLeft)
		{
			List<string> mobaIconList = this._doc.GetMobaIconList(data, this._doc.MobaData.DamageMaxUid, this._doc.MobaData.BeHitMaxUid, this._killMax, this._AssistsMax);
			for (int i = 0; i < mobaIconList.Count; i++)
			{
				this.AddIcon(ts, mobaIconList[i], i, isLeft);
			}
		}

		private void AddIcon(Transform ts, string iconName, int index, bool isLeft)
		{
			GameObject gameObject = this.m_IconPool.FetchGameObject(false);
			gameObject.transform.parent = ts;
			int num = isLeft ? 1 : -1;
			gameObject.transform.localPosition = new Vector3((float)(index * num * this.m_IconPool.TplWidth), 0f);
			IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.spriteName = iconName;
		}

		private void SetupBattleDataUI()
		{
			this.m_PVPDataFrame.SetActive(false);
			IXUILabel ixuilabel = this.m_PVPDataFrame.gameObject.transform.Find("Time").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(string.Format("{0} {1}", XStringDefineProxy.GetString("LEVEL_FINISH_TIME"), XSingleton<UiUtility>.singleton.TimeFormatString(this._doc.LevelFinishTime, 2, 3, 4, false, true)));
			this.m_BattleDataPool.ReturnAll(false);
			Vector3 vector = this.m_BattleDataPool.TplPos;
			for (int i = 0; i < this._doc.MobaData.Team1Data.Count; i++)
			{
				GameObject gameObject = this.m_BattleDataPool.FetchGameObject(false);
				this.SetupBattleDataDetailUI(gameObject, this._doc.MobaData.Team1Data[i], true);
				gameObject.transform.localPosition = vector;
				vector += new Vector3(0f, (float)(-(float)this.m_BattleDataPool.TplHeight));
			}
			for (int j = 0; j < this._doc.MobaData.Team2Data.Count; j++)
			{
				GameObject gameObject2 = this.m_BattleDataPool.FetchGameObject(false);
				this.SetupBattleDataDetailUI(gameObject2, this._doc.MobaData.Team2Data[j], false);
				gameObject2.transform.localPosition = vector;
				vector += new Vector3(0f, (float)(-(float)this.m_BattleDataPool.TplHeight));
			}
		}

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
			uint heroIDByRoleID = this._mobaDoc.GetHeroIDByRoleID(data.uID);
			bool flag = heroIDByRoleID == 0U;
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
				XHeroBattleDocument.GetIconByHeroID(heroIDByRoleID, out strAtlas, out strSprite);
				ixuisprite.SetSprite(strSprite, strAtlas, false);
			}
			ixuilabel.SetText(data.Name);
			transform.gameObject.SetActive(isteam1);
			transform2.gameObject.SetActive(!isteam1);
			gameObject2.SetActive(data.uID == this._doc.MobaData.MvpData.uID);
			ixuilabel2.SetText(data.KillCount.ToString());
			ixuilabel3.SetText(data.MaxKillCount.ToString());
			ixuilabel4.SetText(data.DeathCount.ToString());
			ixuilabel5.SetText(XSingleton<UiUtility>.singleton.NumberFormat(data.Damage));
			ixuilabel6.SetText(XSingleton<UiUtility>.singleton.NumberFormat(data.Heal));
		}

		private XLevelRewardDocument _doc = null;

		private XMobaBattleDocument _mobaDoc = null;

		private XUIPool m_PlayerPool_L = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_PlayerPool_R = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_IconPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_BattleDataPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private GameObject m_Win;

		private GameObject m_Lose;

		private GameObject m_Draw;

		private IXUIButton m_BackBtn;

		private IXUIButton m_BattleDataBtn;

		private IXUIButton m_BattleDataCloseBtn;

		private IXUILabel m_Time;

		private IXUIButton m_ShareBtn;

		public GameObject m_PVPDataFrame;

		private float m_leaveTime;

		private int _killMax;

		private int _DeathMin;

		private int _AssistsMax;
	}
}
