using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B9E RID: 2974
	internal class LevelRewardCustomBattleHandler : DlgHandlerBase
	{
		// Token: 0x17003043 RID: 12355
		// (get) Token: 0x0600AA9B RID: 43675 RVA: 0x001E9E70 File Offset: 0x001E8070
		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardCustomBattleFrame";
			}
		}

		// Token: 0x0600AA9C RID: 43676 RVA: 0x001E9E87 File Offset: 0x001E8087
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.InitUI();
			this.InitDetailUI();
		}

		// Token: 0x0600AA9D RID: 43677 RVA: 0x001E9EB0 File Offset: 0x001E80B0
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

		// Token: 0x0600AA9E RID: 43678 RVA: 0x001E9FD0 File Offset: 0x001E81D0
		private void InitDetailUI()
		{
			this.m_pvp_data_frame = base.PanelObject.transform.Find("Bg/PVPDataFrame");
			Transform transform = this.m_pvp_data_frame.Find("Panel/MemberTpl");
			this.m_battle_data_pool.SetupPool(transform.parent.gameObject, transform.gameObject, 8U, false);
			this.m_battle_data_close_button = (this.m_pvp_data_frame.Find("Close").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x0600AA9F RID: 43679 RVA: 0x001EA050 File Offset: 0x001E8250
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_battle_data_button.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBattleDataButtonClicked));
			this.m_return_button.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnButtonClicked));
			this.m_battle_data_close_button.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnDetailCloseButtonClicked));
		}

		// Token: 0x0600AAA0 RID: 43680 RVA: 0x001EA0B0 File Offset: 0x001E82B0
		private bool OnBattleDataButtonClicked(IXUIButton button)
		{
			this.m_pvp_data_frame.gameObject.SetActive(true);
			return true;
		}

		// Token: 0x0600AAA1 RID: 43681 RVA: 0x001EA0D8 File Offset: 0x001E82D8
		private bool OnReturnButtonClicked(IXUIButton button)
		{
			this.doc.SendLeaveScene();
			return true;
		}

		// Token: 0x0600AAA2 RID: 43682 RVA: 0x001EA0F8 File Offset: 0x001E82F8
		private bool OnDetailCloseButtonClicked(IXUIButton button)
		{
			this.m_pvp_data_frame.gameObject.SetActive(false);
			return true;
		}

		// Token: 0x0600AAA3 RID: 43683 RVA: 0x001EA11D File Offset: 0x001E831D
		private void OnAddFriendClick(IXUISprite sp)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(sp.ID);
		}

		// Token: 0x0600AAA4 RID: 43684 RVA: 0x001EA131 File Offset: 0x001E8331
		private void OnAddOtherServerFriendClick(IXUISprite sp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ADD_OTHER_SERVER_FRIEND"), "fece00");
		}

		// Token: 0x0600AAA5 RID: 43685 RVA: 0x001EA153 File Offset: 0x001E8353
		protected override void OnShow()
		{
			base.OnShow();
			this.OnShowUI();
			this.SetupBattleDataUI();
		}

		// Token: 0x0600AAA6 RID: 43686 RVA: 0x001EA16C File Offset: 0x001E836C
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

		// Token: 0x0600AAA7 RID: 43687 RVA: 0x001EA328 File Offset: 0x001E8528
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

		// Token: 0x0600AAA8 RID: 43688 RVA: 0x001EA48C File Offset: 0x001E868C
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

		// Token: 0x0600AAA9 RID: 43689 RVA: 0x001EA5BC File Offset: 0x001E87BC
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

		// Token: 0x04003F62 RID: 16226
		private XLevelRewardDocument doc = null;

		// Token: 0x04003F63 RID: 16227
		private Transform m_win;

		// Token: 0x04003F64 RID: 16228
		private Transform m_lose;

		// Token: 0x04003F65 RID: 16229
		private Transform m_draw;

		// Token: 0x04003F66 RID: 16230
		private IXUIButton m_battle_data_button;

		// Token: 0x04003F67 RID: 16231
		private IXUIButton m_return_button;

		// Token: 0x04003F68 RID: 16232
		private XUIPool m_team1_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003F69 RID: 16233
		private XUIPool m_team2_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003F6A RID: 16234
		private Transform m_pvp_data_frame;

		// Token: 0x04003F6B RID: 16235
		private XUIPool m_battle_data_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003F6C RID: 16236
		private IXUIButton m_battle_data_close_button;
	}
}
