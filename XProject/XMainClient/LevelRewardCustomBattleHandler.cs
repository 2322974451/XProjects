using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardCustomBattleHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardCustomBattleFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.InitUI();
			this.InitDetailUI();
		}

		private void InitUI()
		{
			this.m_win = base.PanelObject.transform.Find("Bg/Result/win");
			this.m_lose = base.PanelObject.transform.Find("Bg/Result/lose");
			this.m_draw = base.PanelObject.transform.Find("Bg/Result/draw");
			this.m_battle_data_button = (base.PanelObject.transform.Find("Bg/button/BattleData").GetComponent("XUIButton") as IXUIButton);
			this.m_return_button = (base.PanelObject.transform.Find("Bg/button/Continue").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.PanelObject.transform.Find("Bg/Board/team1/Panel/PlayerTpl");
			this.m_team1_pool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			transform = base.PanelObject.transform.Find("Bg/Board/team2/Panel/PlayerTpl");
			this.m_team2_pool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
		}

		private void InitDetailUI()
		{
			this.m_pvp_data_frame = base.PanelObject.transform.Find("Bg/PVPDataFrame");
			Transform transform = this.m_pvp_data_frame.Find("Panel/MemberTpl");
			this.m_battle_data_pool.SetupPool(transform.parent.gameObject, transform.gameObject, 8U, false);
			this.m_battle_data_close_button = (this.m_pvp_data_frame.Find("Close").GetComponent("XUIButton") as IXUIButton);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_battle_data_button.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBattleDataButtonClicked));
			this.m_return_button.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnButtonClicked));
			this.m_battle_data_close_button.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnDetailCloseButtonClicked));
		}

		private bool OnBattleDataButtonClicked(IXUIButton button)
		{
			this.m_pvp_data_frame.gameObject.SetActive(true);
			return true;
		}

		private bool OnReturnButtonClicked(IXUIButton button)
		{
			this.doc.SendLeaveScene();
			return true;
		}

		private bool OnDetailCloseButtonClicked(IXUIButton button)
		{
			this.m_pvp_data_frame.gameObject.SetActive(false);
			return true;
		}

		private void OnAddFriendClick(IXUISprite sp)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(sp.ID);
		}

		private void OnAddOtherServerFriendClick(IXUISprite sp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ADD_OTHER_SERVER_FRIEND"), "fece00");
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.OnShowUI();
			this.SetupBattleDataUI();
		}

		private void OnShowUI()
		{
			this.m_pvp_data_frame.gameObject.SetActive(false);
			this.m_win.gameObject.SetActive(this.doc.CustomBattleData.Result == PkResultType.PkResult_Win);
			this.m_lose.gameObject.SetActive(this.doc.CustomBattleData.Result == PkResultType.PkResult_Lose);
			this.m_draw.gameObject.SetActive(this.doc.CustomBattleData.Result == PkResultType.PkResult_Draw);
			this.m_team1_pool.ReturnAll(false);
			for (int i = 0; i < this.doc.CustomBattleData.Team1Data.Count; i++)
			{
				GameObject gameObject = this.m_team1_pool.FetchGameObject(false);
				this.SetupDetailUI(gameObject, this.doc.CustomBattleData.Team1Data[i]);
				gameObject.transform.localPosition = this.m_team1_pool.TplPos - new Vector3(0f, (float)(this.m_team1_pool.TplHeight * i));
			}
			this.m_team2_pool.ReturnAll(false);
			for (int j = 0; j < this.doc.CustomBattleData.Team2Data.Count; j++)
			{
				GameObject gameObject2 = this.m_team2_pool.FetchGameObject(false);
				this.SetupDetailUI(gameObject2, this.doc.CustomBattleData.Team2Data[j]);
				gameObject2.transform.localPosition = this.m_team2_pool.TplPos - new Vector3(0f, (float)(this.m_team2_pool.TplHeight * j));
			}
		}

		private void SetupDetailUI(GameObject go, XLevelRewardDocument.CustomBattleInfo data)
		{
			IXUISprite ixuisprite = go.transform.Find("Avatar").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite2 = go.transform.Find("MVP").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = go.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.Find("Kill").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = go.transform.Find("Death").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel4 = go.transform.Find("Point").GetComponent("XUILabel") as IXUILabel;
			ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon(data.RoleProf));
			ixuisprite2.SetAlpha((float)(data.IsMvp ? 1 : 0));
			ixuilabel.SetText(data.RoleName);
			ixuilabel2.SetText(data.KillCount.ToString());
			ixuilabel3.SetText(data.DeathCount.ToString());
			ixuilabel4.SetText((data.PointChange > 0) ? ("+" + data.PointChange.ToString()) : data.PointChange.ToString());
		}

		private void SetupBattleDataUI()
		{
			this.m_battle_data_pool.ReturnAll(false);
			Vector3 vector = this.m_battle_data_pool.TplPos;
			for (int i = 0; i < this.doc.CustomBattleData.Team1Data.Count; i++)
			{
				GameObject gameObject = this.m_battle_data_pool.FetchGameObject(false);
				this.SetupBattleDataDetailUI(gameObject, this.doc.CustomBattleData.Team1Data[i], true);
				gameObject.transform.localPosition = vector;
				vector += new Vector3(0f, (float)(-(float)this.m_battle_data_pool.TplHeight));
			}
			for (int j = 0; j < this.doc.CustomBattleData.Team2Data.Count; j++)
			{
				GameObject gameObject2 = this.m_battle_data_pool.FetchGameObject(false);
				this.SetupBattleDataDetailUI(gameObject2, this.doc.CustomBattleData.Team2Data[j], false);
				gameObject2.transform.localPosition = vector;
				vector += new Vector3(0f, (float)(-(float)this.m_battle_data_pool.TplHeight));
			}
		}

		private void SetupBattleDataDetailUI(GameObject go, XLevelRewardDocument.CustomBattleInfo data, bool isteam1)
		{
			IXUISprite ixuisprite = go.transform.Find("Detail/Avatar").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = go.transform.Find("Detail/Name").GetComponent("XUILabel") as IXUILabel;
			Transform transform = go.transform.Find("Detail/Team1");
			Transform transform2 = go.transform.Find("Detail/Team2");
			IXUILabel ixuilabel2 = go.transform.Find("KillTotal").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = go.transform.Find("MaxKill").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel4 = go.transform.Find("DeathCount").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel5 = go.transform.Find("DamageTotal").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel6 = go.transform.Find("HealTotal").GetComponent("XUILabel") as IXUILabel;
			ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon(data.RoleProf));
			ixuilabel.SetText(data.RoleName);
			transform.gameObject.SetActive(isteam1);
			transform2.gameObject.SetActive(!isteam1);
			ixuilabel2.SetText(data.KillCount.ToString());
			ixuilabel3.SetText(data.MaxKillCount.ToString());
			ixuilabel4.SetText(data.DeathCount.ToString());
			ixuilabel5.SetText(XSingleton<UiUtility>.singleton.NumberFormat(data.Damage));
			ixuilabel6.SetText(XSingleton<UiUtility>.singleton.NumberFormat(data.Heal));
		}

		private XLevelRewardDocument doc = null;

		private Transform m_win;

		private Transform m_lose;

		private Transform m_draw;

		private IXUIButton m_battle_data_button;

		private IXUIButton m_return_button;

		private XUIPool m_team1_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_team2_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Transform m_pvp_data_frame;

		private XUIPool m_battle_data_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUIButton m_battle_data_close_button;
	}
}
