using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardPVPHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardPVPFrame";
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
			Transform transform = base.PanelObject.transform.Find("ItemList/ItemTpl");
			this.m_item_pool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, true);
			this.m_win = base.PanelObject.transform.Find("Win");
			this.m_lose = base.PanelObject.transform.Find("Lose");
			this.m_draw = base.PanelObject.transform.Find("Draw");
			this.m_battle_data_button = (base.PanelObject.transform.Find("BattleData").GetComponent("XUIButton") as IXUIButton);
			this.m_return_button = (base.PanelObject.transform.Find("Return").GetComponent("XUIButton") as IXUIButton);
			transform = base.PanelObject.transform.Find("Team1/DetailTpl");
			this.m_team1_pool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, true);
			transform = base.PanelObject.transform.Find("Team2/DetailTpl");
			this.m_team2_pool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, true);
		}

		private void InitDetailUI()
		{
			this.m_pvp_data_frame = base.PanelObject.transform.Find("PVPDataFrame");
			Transform transform = this.m_pvp_data_frame.Find("Panel/MemberTpl");
			this.m_battle_data_pool.SetupPool(transform.parent.gameObject, transform.gameObject, 8U, false);
			this.m_battle_data_close_button = (this.m_pvp_data_frame.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_watch = (this.m_pvp_data_frame.transform.Find("Watch").GetComponent("XUILabel") as IXUILabel);
			this.m_like = (this.m_pvp_data_frame.transform.Find("Like").GetComponent("XUILabel") as IXUILabel);
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
			this.m_win.gameObject.SetActive(this.doc.PvpBattleData.PVPResult == 1);
			this.m_lose.gameObject.SetActive(this.doc.PvpBattleData.PVPResult == 2);
			this.m_draw.gameObject.SetActive(this.doc.PvpBattleData.PVPResult == 3);
			this.m_team1_pool.ReturnAll(false);
			for (int i = 0; i < this.doc.PvpBattleData.Team1Data.Count; i++)
			{
				GameObject gameObject = this.m_team1_pool.FetchGameObject(false);
				this.SetupDetailUI(gameObject, this.doc.PvpBattleData.Team1Data[i]);
				gameObject.transform.localPosition = this.m_team1_pool.TplPos - new Vector3(0f, (float)(this.m_team1_pool.TplHeight * i));
			}
			this.m_team2_pool.ReturnAll(false);
			for (int j = 0; j < this.doc.PvpBattleData.Team2Data.Count; j++)
			{
				GameObject gameObject2 = this.m_team2_pool.FetchGameObject(false);
				this.SetupDetailUI(gameObject2, this.doc.PvpBattleData.Team2Data[j]);
				gameObject2.transform.localPosition = this.m_team2_pool.TplPos - new Vector3(0f, (float)(this.m_team2_pool.TplHeight * j));
			}
			this.m_item_pool.ReturnAll(false);
			int num = this.doc.PvpBattleData.DayJoinReward.Count + this.doc.PvpBattleData.WinReward.Count;
			Vector3 vector = this.m_item_pool.TplPos + new Vector3(0.5f * (float)(1 - num) * (float)this.m_item_pool.TplWidth, 0f);
			for (int k = 0; k < this.doc.PvpBattleData.DayJoinReward.Count; k++)
			{
				GameObject gameObject3 = this.m_item_pool.FetchGameObject(false);
				IXUILabel ixuilabel = gameObject3.transform.Find("Day").GetComponent("XUILabel") as IXUILabel;
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject3, (int)this.doc.PvpBattleData.DayJoinReward[k].itemID, (int)this.doc.PvpBattleData.DayJoinReward[k].itemCount, false);
				ixuilabel.Alpha = 1f;
				gameObject3.transform.localPosition = vector;
				vector += new Vector3((float)this.m_item_pool.TplWidth, 0f);
			}
			for (int l = 0; l < this.doc.PvpBattleData.WinReward.Count; l++)
			{
				GameObject gameObject4 = this.m_item_pool.FetchGameObject(false);
				IXUILabel ixuilabel2 = gameObject4.transform.Find("Day").GetComponent("XUILabel") as IXUILabel;
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject4, (int)this.doc.PvpBattleData.WinReward[l].itemID, (int)this.doc.PvpBattleData.WinReward[l].itemCount, false);
				ixuilabel2.Alpha = 0f;
				gameObject4.transform.localPosition = vector;
				vector += new Vector3((float)this.m_item_pool.TplWidth, 0f);
			}
		}

		private void SetupDetailUI(GameObject go, XLevelRewardDocument.PVPRoleInfo data)
		{
			IXUISprite ixuisprite = go.transform.Find("Avatar").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite2 = go.transform.Find("MVP").GetComponent("XUISprite") as IXUISprite;
			IXUILabelSymbol ixuilabelSymbol = go.transform.Find("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabel ixuilabel = go.transform.Find("Level").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.Find("Kill").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = go.transform.Find("Death").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite3 = go.transform.Find("AddFriend").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon(data.Prof));
			ixuisprite2.SetAlpha((float)(data.IsMvp ? 1 : 0));
			ixuilabelSymbol.InputText = XMilitaryRankDocument.GetMilitaryRankWithFormat(data.militaryRank, data.Name, true);
			ixuilabel.SetText(string.Format("Lv.{0}", data.Level.ToString()));
			ixuilabel2.SetText(data.KillCount.ToString());
			ixuilabel3.SetText(data.DeathCount.ToString());
			ixuisprite3.ID = data.uID;
			bool flag = data.uID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID || DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsMyFriend(ixuisprite3.ID);
			if (flag)
			{
				ixuisprite3.SetVisible(false);
			}
			else
			{
				bool flag2 = XSingleton<XClientNetwork>.singleton.ServerID == data.ServerID;
				if (flag2)
				{
					ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAddFriendClick));
				}
				else
				{
					ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAddOtherServerFriendClick));
				}
			}
		}

		private void SetupBattleDataUI()
		{
			bool flag = XSpectateSceneDocument.WhetherWathchNumShow((int)this.doc.WatchCount, (int)this.doc.LikeCount, (int)this.doc.CurrentStage);
			if (flag)
			{
				this.m_watch.SetVisible(true);
				this.m_like.SetVisible(true);
				this.m_watch.SetText(this.doc.WatchCount.ToString());
				this.m_like.SetText(this.doc.LikeCount.ToString());
			}
			else
			{
				this.m_watch.SetVisible(false);
				this.m_like.SetVisible(false);
			}
			this.m_battle_data_pool.ReturnAll(false);
			Vector3 vector = this.m_battle_data_pool.TplPos;
			for (int i = 0; i < this.doc.PvpBattleData.Team1Data.Count; i++)
			{
				GameObject gameObject = this.m_battle_data_pool.FetchGameObject(false);
				this.SetupBattleDataDetailUI(gameObject, this.doc.PvpBattleData.Team1Data[i], true);
				gameObject.transform.localPosition = vector;
				vector += new Vector3(0f, (float)(-(float)this.m_battle_data_pool.TplHeight));
			}
			for (int j = 0; j < this.doc.PvpBattleData.Team2Data.Count; j++)
			{
				GameObject gameObject2 = this.m_battle_data_pool.FetchGameObject(false);
				this.SetupBattleDataDetailUI(gameObject2, this.doc.PvpBattleData.Team2Data[j], false);
				gameObject2.transform.localPosition = vector;
				vector += new Vector3(0f, (float)(-(float)this.m_battle_data_pool.TplHeight));
			}
		}

		private void SetupBattleDataDetailUI(GameObject go, XLevelRewardDocument.PVPRoleInfo data, bool isteam1)
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
			ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon(data.Prof));
			ixuilabel.SetText(data.Name);
			transform.gameObject.SetActive(isteam1);
			transform2.gameObject.SetActive(!isteam1);
			ixuilabel2.SetText(data.KillCount.ToString());
			ixuilabel3.SetText(data.MaxKillCount.ToString());
			ixuilabel4.SetText(data.DeathCount.ToString());
			ixuilabel5.SetText(XSingleton<UiUtility>.singleton.NumberFormat(data.Damage));
			ixuilabel6.SetText(XSingleton<UiUtility>.singleton.NumberFormat(data.Heal));
		}

		private XLevelRewardDocument doc = null;

		private XUIPool m_item_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Transform m_win;

		private Transform m_lose;

		private Transform m_draw;

		private IXUIButton m_battle_data_button;

		private IXUIButton m_return_button;

		private IXUILabel m_watch;

		private IXUILabel m_like;

		private XUIPool m_team1_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_team2_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Transform m_pvp_data_frame;

		private XUIPool m_battle_data_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUIButton m_battle_data_close_button;
	}
}
