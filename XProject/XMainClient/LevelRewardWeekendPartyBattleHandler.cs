using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardWeekendPartyBattleHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardWeekendParty";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.m_Win = base.PanelObject.transform.Find("Bg/Result/win").gameObject;
			this.m_Lose = base.PanelObject.transform.Find("Bg/Result/lose").gameObject;
			this.m_Draw = base.PanelObject.transform.Find("Bg/Result/draw").gameObject;
			this.m_Time = (base.PanelObject.transform.Find("Bg/Board/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_BackBtn = (base.PanelObject.transform.Find("Bg/button/Continue").GetComponent("XUIButton") as IXUIButton);
			this.m_Score1 = (base.PanelObject.transform.Find("Bg/Board/team1/Score/T").GetComponent("XUILabel") as IXUILabel);
			this.m_Score2 = (base.PanelObject.transform.Find("Bg/Board/team2/Score/T").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.PanelObject.transform.Find("Bg/Board/team1/Panel/PlayerTpl");
			this.m_PlayerPool_L.SetupPool(transform.parent.gameObject, transform.gameObject, 8U, false);
			transform = base.PanelObject.transform.Find("Bg/Board/team2/Panel/PlayerTpl");
			this.m_PlayerPool_R.SetupPool(transform.parent.gameObject, transform.gameObject, 8U, false);
			transform = base.PanelObject.transform.Find("Bg/button/Reward/ItemTpl");
			this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 24U, false);
			this.m_TypeKill = base.PanelObject.transform.Find("Bg/Board/Game_kill").gameObject;
			this.m_TypeDeath = base.PanelObject.transform.Find("Bg/Board/Game_death").gameObject;
			this.m_TypeTime = base.PanelObject.transform.Find("Bg/Board/Game_time").gameObject;
			this.m_TypeRank = base.PanelObject.transform.Find("Bg/Board/Game_rank").gameObject;
			this.m_TypeOnlyScore = base.PanelObject.transform.Find("Bg/Board/Game_OnlyScore").gameObject;
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BackBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBackBtnClick));
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
			this.ShowUI();
		}

		public void ShowUI()
		{
			DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.SetVisible(true, true);
			base.SetVisible(true);
			this.m_Time.SetText(XSingleton<UiUtility>.singleton.TimeFormatString((int)this._doc.WeekendPartyBattleData.WarTime, 2, 3, 4, false, true));
			this.m_Win.SetActive(this._doc.WeekendPartyBattleData.Team1Score > this._doc.WeekendPartyBattleData.Team2Score);
			this.m_Lose.SetActive(this._doc.WeekendPartyBattleData.Team1Score < this._doc.WeekendPartyBattleData.Team2Score);
			this.m_Draw.SetActive(this._doc.WeekendPartyBattleData.Team1Score == this._doc.WeekendPartyBattleData.Team2Score);
			this.m_Score1.SetText(this._doc.WeekendPartyBattleData.Team1Score.ToString());
			this.m_Score2.SetText(this._doc.WeekendPartyBattleData.Team2Score.ToString());
			this.m_TypeKill.SetActive(false);
			this.m_TypeDeath.SetActive(false);
			this.m_TypeTime.SetActive(false);
			this.m_TypeRank.SetActive(false);
			this.m_TypeOnlyScore.SetActive(false);
			switch (XSingleton<XScene>.singleton.SceneType)
			{
			case SceneType.SCENE_WEEKEND4V4_MONSTERFIGHT:
				this.m_TypeKill.SetActive(true);
				break;
			case SceneType.SCENE_WEEKEND4V4_GHOSTACTION:
			case SceneType.SCENE_WEEKEND4V4_DUCK:
				this.m_TypeOnlyScore.SetActive(true);
				break;
			case SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE:
				this.m_TypeDeath.SetActive(true);
				break;
			case SceneType.SCENE_WEEKEND4V4_CRAZYBOMB:
				this.m_TypeDeath.SetActive(true);
				break;
			case SceneType.SCENE_WEEKEND4V4_HORSERACING:
				this.m_TypeRank.SetActive(true);
				break;
			}
			this._doc.WeekendPartyBattleData.AllRoleData.Sort(new Comparison<WeekendPartyBattleRoleInfo>(XWeekendPartyDocument.SortRoleRank));
			this.m_PlayerPool_L.ReturnAll(false);
			this.m_PlayerPool_R.ReturnAll(false);
			int num = 0;
			int num2 = 0;
			uint num3 = (this._doc.WeekendPartyBattleData.AllRoleData.Count > 0) ? this._doc.WeekendPartyBattleData.AllRoleData[0].score : 0U;
			uint num4 = (this._doc.WeekendPartyBattleData.AllRoleData.Count > 0) ? this._doc.WeekendPartyBattleData.AllRoleData[0].beKilled : 0U;
			for (int i = 0; i < this._doc.WeekendPartyBattleData.AllRoleData.Count; i++)
			{
				this._doc.WeekendPartyBattleData.AllRoleData[i].Rank = i + 1;
				bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_CRAZYBOMB || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE;
				bool isMVP;
				if (flag)
				{
					isMVP = (this._doc.WeekendPartyBattleData.AllRoleData[i].beKilled == num4);
				}
				else
				{
					isMVP = (this._doc.WeekendPartyBattleData.AllRoleData[i].score == num3);
				}
				bool flag2 = this._doc.WeekendPartyBattleData.AllRoleData[i].redBlue == this._doc.WeekendPartyBattleData.PlayerRedBlue;
				XSingleton<XDebug>.singleton.AddLog("WeekendPary result Name = " + this._doc.WeekendPartyBattleData.AllRoleData[i].roleName + ", redblue = " + this._doc.WeekendPartyBattleData.AllRoleData[i].redBlue.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
				XSingleton<XDebug>.singleton.AddLog("WeekendPary result isLeft = " + flag2.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
				this.SetupData(flag2 ? this.m_PlayerPool_L.FetchGameObject(false) : this.m_PlayerPool_R.FetchGameObject(false), this._doc.WeekendPartyBattleData.AllRoleData[i], flag2 ? num : num2, flag2, isMVP);
				bool flag3 = flag2;
				if (flag3)
				{
					num++;
				}
				else
				{
					num2++;
				}
			}
			bool flag4 = false;
			for (int j = 0; j < this._doc.WeekendPartyBattleData.HasRewardsID.Count; j++)
			{
				bool flag5 = this._doc.WeekendPartyBattleData.HasRewardsID[j] == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag5)
				{
					flag4 = true;
				}
			}
			bool flag6 = flag4;
			if (flag6)
			{
				XWeekendPartyDocument specificDocument = XDocuments.GetSpecificDocument<XWeekendPartyDocument>(XWeekendPartyDocument.uuID);
				WeekEnd4v4List.RowData activityInfo = specificDocument.GetActivityInfo(specificDocument.CurrActID);
				bool flag7 = activityInfo != null;
				if (flag7)
				{
					SeqListRef<uint> seqListRef = (this._doc.WeekendPartyBattleData.Team1Score > this._doc.WeekendPartyBattleData.Team2Score) ? activityInfo.DropItems : activityInfo.LoseDrop;
					this.m_ItemPool.ReturnAll(false);
					Vector3 vector = this.m_ItemPool.TplPos;
					for (int k = 0; k < seqListRef.Count; k++)
					{
						GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)seqListRef[k, 0], (int)seqListRef[k, 1], false);
						gameObject.transform.localPosition = vector;
						vector += new Vector3((float)this.m_ItemPool.TplWidth, 0f);
					}
				}
			}
		}

		private void SetupData(GameObject go, WeekendPartyBattleRoleInfo data, int index, bool isLeft, bool isMVP)
		{
			Vector3 tplPos = this.m_PlayerPool_L.TplPos;
			go.transform.localScale = Vector3.one;
			go.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(index * this.m_PlayerPool_L.TplHeight));
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag)
			{
				GameObject gameObject = go.transform.Find("me").gameObject;
				gameObject.SetActive(data.roleID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID);
			}
			IXUILabel ixuilabel = go.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(data.roleName);
			IXUISprite ixuisprite = go.transform.Find("Avatar").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon(data.RoleProf);
			GameObject gameObject2 = go.transform.Find("MVP").gameObject;
			gameObject2.SetActive(isMVP);
			IXUILabel ixuilabel2 = go.transform.Find("Death").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = go.transform.Find("Point").GetComponent("XUILabel") as IXUILabel;
			switch (XSingleton<XScene>.singleton.SceneType)
			{
			case SceneType.SCENE_WEEKEND4V4_MONSTERFIGHT:
				ixuilabel2.SetText(data.kill.ToString());
				ixuilabel3.SetText(data.score.ToString());
				break;
			case SceneType.SCENE_WEEKEND4V4_GHOSTACTION:
			case SceneType.SCENE_WEEKEND4V4_DUCK:
				ixuilabel2.SetVisible(false);
				ixuilabel3.SetText(data.score.ToString());
				break;
			case SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE:
				ixuilabel2.SetVisible(false);
				ixuilabel3.SetText(data.beKilled.ToString());
				break;
			case SceneType.SCENE_WEEKEND4V4_CRAZYBOMB:
				ixuilabel2.SetVisible(false);
				ixuilabel3.SetText(data.beKilled.ToString());
				break;
			case SceneType.SCENE_WEEKEND4V4_HORSERACING:
				ixuilabel2.SetText(data.Rank.ToString());
				ixuilabel3.SetText(data.score.ToString());
				break;
			}
		}

		private XLevelRewardDocument _doc = null;

		private XUIPool m_PlayerPool_L = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_PlayerPool_R = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private GameObject m_Win;

		private GameObject m_Lose;

		private GameObject m_Draw;

		private IXUIButton m_BackBtn;

		private IXUILabel m_Time;

		private IXUILabel m_Score1;

		private IXUILabel m_Score2;

		private GameObject m_TypeKill;

		private GameObject m_TypeDeath;

		private GameObject m_TypeTime;

		private GameObject m_TypeRank;

		private GameObject m_TypeOnlyScore;

		private float m_leaveTime;
	}
}
