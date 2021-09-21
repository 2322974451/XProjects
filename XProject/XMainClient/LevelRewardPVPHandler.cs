using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BA8 RID: 2984
	internal class LevelRewardPVPHandler : DlgHandlerBase
	{
		// Token: 0x1700304C RID: 12364
		// (get) Token: 0x0600AB13 RID: 43795 RVA: 0x001F0268 File Offset: 0x001EE468
		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardPVPFrame";
			}
		}

		// Token: 0x0600AB14 RID: 43796 RVA: 0x001F027F File Offset: 0x001EE47F
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.InitUI();
			this.InitDetailUI();
		}

		// Token: 0x0600AB15 RID: 43797 RVA: 0x001F02A8 File Offset: 0x001EE4A8
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

		// Token: 0x0600AB16 RID: 43798 RVA: 0x001F03FC File Offset: 0x001EE5FC
		private void InitDetailUI()
		{
			this.m_pvp_data_frame = base.PanelObject.transform.Find("PVPDataFrame");
			Transform transform = this.m_pvp_data_frame.Find("Panel/MemberTpl");
			this.m_battle_data_pool.SetupPool(transform.parent.gameObject, transform.gameObject, 8U, false);
			this.m_battle_data_close_button = (this.m_pvp_data_frame.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_watch = (this.m_pvp_data_frame.transform.Find("Watch").GetComponent("XUILabel") as IXUILabel);
			this.m_like = (this.m_pvp_data_frame.transform.Find("Like").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600AB17 RID: 43799 RVA: 0x001F04D0 File Offset: 0x001EE6D0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_battle_data_button.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBattleDataButtonClicked));
			this.m_return_button.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnButtonClicked));
			this.m_battle_data_close_button.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnDetailCloseButtonClicked));
		}

		// Token: 0x0600AB18 RID: 43800 RVA: 0x001F0530 File Offset: 0x001EE730
		private bool OnBattleDataButtonClicked(IXUIButton button)
		{
			this.m_pvp_data_frame.gameObject.SetActive(true);
			return true;
		}

		// Token: 0x0600AB19 RID: 43801 RVA: 0x001F0558 File Offset: 0x001EE758
		private bool OnReturnButtonClicked(IXUIButton button)
		{
			this.doc.SendLeaveScene();
			return true;
		}

		// Token: 0x0600AB1A RID: 43802 RVA: 0x001F0578 File Offset: 0x001EE778
		private bool OnDetailCloseButtonClicked(IXUIButton button)
		{
			this.m_pvp_data_frame.gameObject.SetActive(false);
			return true;
		}

		// Token: 0x0600AB1B RID: 43803 RVA: 0x001EA11D File Offset: 0x001E831D
		private void OnAddFriendClick(IXUISprite sp)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(sp.ID);
		}

		// Token: 0x0600AB1C RID: 43804 RVA: 0x001EA131 File Offset: 0x001E8331
		private void OnAddOtherServerFriendClick(IXUISprite sp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ADD_OTHER_SERVER_FRIEND"), "fece00");
		}

		// Token: 0x0600AB1D RID: 43805 RVA: 0x001F059D File Offset: 0x001EE79D
		protected override void OnShow()
		{
			base.OnShow();
			this.OnShowUI();
			this.SetupBattleDataUI();
		}

		// Token: 0x0600AB1E RID: 43806 RVA: 0x001F05B8 File Offset: 0x001EE7B8
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

		// Token: 0x0600AB1F RID: 43807 RVA: 0x001F09B0 File Offset: 0x001EEBB0
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

		// Token: 0x0600AB20 RID: 43808 RVA: 0x001F0BC0 File Offset: 0x001EEDC0
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

		// Token: 0x0600AB21 RID: 43809 RVA: 0x001F0D98 File Offset: 0x001EEF98
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

		// Token: 0x04003FDD RID: 16349
		private XLevelRewardDocument doc = null;

		// Token: 0x04003FDE RID: 16350
		private XUIPool m_item_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003FDF RID: 16351
		private Transform m_win;

		// Token: 0x04003FE0 RID: 16352
		private Transform m_lose;

		// Token: 0x04003FE1 RID: 16353
		private Transform m_draw;

		// Token: 0x04003FE2 RID: 16354
		private IXUIButton m_battle_data_button;

		// Token: 0x04003FE3 RID: 16355
		private IXUIButton m_return_button;

		// Token: 0x04003FE4 RID: 16356
		private IXUILabel m_watch;

		// Token: 0x04003FE5 RID: 16357
		private IXUILabel m_like;

		// Token: 0x04003FE6 RID: 16358
		private XUIPool m_team1_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003FE7 RID: 16359
		private XUIPool m_team2_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003FE8 RID: 16360
		private Transform m_pvp_data_frame;

		// Token: 0x04003FE9 RID: 16361
		private XUIPool m_battle_data_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003FEA RID: 16362
		private IXUIButton m_battle_data_close_button;
	}
}
