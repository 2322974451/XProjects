using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A2B RID: 2603
	internal class LevelRewardBattleFieldHandler : DlgHandlerBase
	{
		// Token: 0x17002ECE RID: 11982
		// (get) Token: 0x06009EDB RID: 40667 RVA: 0x001A35AC File Offset: 0x001A17AC
		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardBattleFieldFrame";
			}
		}

		// Token: 0x06009EDC RID: 40668 RVA: 0x001A35C3 File Offset: 0x001A17C3
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.InitUI();
			this.InitDetailUI();
		}

		// Token: 0x06009EDD RID: 40669 RVA: 0x001A35EC File Offset: 0x001A17EC
		private void InitUI()
		{
			this.m_PlayerPool.SetupPool(null, base.transform.Find("Bg/Rank/Rank/Panel/PlayerTpl").gameObject, 8U, false);
			this.m_ItemPool.SetupPool(null, base.transform.Find("Bg/Bottom/ItemList/Panel/ItemTpl").gameObject, 5U, false);
			this.m_BattleDataButton = (base.transform.Find("Bg/Bottom/BattleData").GetComponent("XUIButton") as IXUIButton);
			this.m_ReturnButton = (base.transform.Find("Bg/Bottom/Return").GetComponent("XUIButton") as IXUIButton);
			this.m_ReturnWaitButton = (base.transform.Find("Bg/Bottom/ReturnWait").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x06009EDE RID: 40670 RVA: 0x001A36B4 File Offset: 0x001A18B4
		private void InitDetailUI()
		{
			this.m_PVPDataFrame = base.PanelObject.transform.Find("Bg/PVPDataFrame");
			this.m_BattleDataPool.SetupPool(null, this.m_PVPDataFrame.Find("Panel/MemberTpl").gameObject, 8U, false);
			this.m_BattleDataCloseButton = (this.m_PVPDataFrame.Find("Close").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x06009EDF RID: 40671 RVA: 0x001A3728 File Offset: 0x001A1928
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BattleDataButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBattleDataButtonClicked));
			this.m_ReturnButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnButtonClicked));
			this.m_ReturnWaitButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnWaitButtonClicked));
			this.m_BattleDataCloseButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnDetailCloseButtonClicked));
		}

		// Token: 0x06009EE0 RID: 40672 RVA: 0x001A37A0 File Offset: 0x001A19A0
		private bool OnBattleDataButtonClicked(IXUIButton button)
		{
			this.m_PVPDataFrame.gameObject.SetActive(true);
			return true;
		}

		// Token: 0x06009EE1 RID: 40673 RVA: 0x001A37C8 File Offset: 0x001A19C8
		private bool OnReturnButtonClicked(IXUIButton button)
		{
			this.doc.SendLeaveScene();
			return true;
		}

		// Token: 0x06009EE2 RID: 40674 RVA: 0x001A37E8 File Offset: 0x001A19E8
		private bool OnReturnWaitButtonClicked(IXUIButton button)
		{
			this.doc.SendReturnWaitBattleField();
			return true;
		}

		// Token: 0x06009EE3 RID: 40675 RVA: 0x001A3808 File Offset: 0x001A1A08
		private bool OnDetailCloseButtonClicked(IXUIButton button)
		{
			this.m_PVPDataFrame.gameObject.SetActive(false);
			return true;
		}

		// Token: 0x06009EE4 RID: 40676 RVA: 0x001A382D File Offset: 0x001A1A2D
		protected override void OnShow()
		{
			base.OnShow();
			this.OnShowUI();
			this.SetupBattleDataUI();
		}

		// Token: 0x06009EE5 RID: 40677 RVA: 0x001A3848 File Offset: 0x001A1A48
		private void OnShowUI()
		{
			this.m_PVPDataFrame.gameObject.SetActive(false);
			XLevelRewardDocument.BattleFieldData battleFieldBattleData = this.doc.BattleFieldBattleData;
			this.m_ReturnWaitButton.gameObject.SetActive(!battleFieldBattleData.allend);
			this.m_PlayerPool.FakeReturnAll();
			for (int i = 0; i < battleFieldBattleData.MemberData.Count; i++)
			{
				GameObject gameObject = this.m_PlayerPool.FetchGameObject(false);
				this.SetupDetailUI(gameObject, battleFieldBattleData.MemberData[i]);
				gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)this.m_PlayerPool.TplHeight * i)) + this.m_PlayerPool.TplPos;
			}
			this.m_PlayerPool.ActualReturnAll(false);
			this.m_ItemPool.FakeReturnAll();
			for (int j = 0; j < battleFieldBattleData.item.Count; j++)
			{
				GameObject gameObject2 = this.m_ItemPool.FetchGameObject(false);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, (int)battleFieldBattleData.item[j].itemID, (int)battleFieldBattleData.item[j].itemCount, false);
				gameObject2.transform.localPosition = new Vector3((float)(j * this.m_ItemPool.TplWidth), 0f, 0f) + this.m_ItemPool.TplPos;
				IXUISprite ixuisprite = gameObject2.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)battleFieldBattleData.item[j].itemID;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
			this.m_ItemPool.ActualReturnAll(false);
		}

		// Token: 0x06009EE6 RID: 40678 RVA: 0x001A3A30 File Offset: 0x001A1C30
		private void SetupDetailUI(GameObject go, XLevelRewardDocument.BattleRankRoleInfo data)
		{
			IXUISprite ixuisprite = go.transform.Find("Avatar").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite2 = go.transform.Find("MVP").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = go.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.Find("ServerName").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = go.transform.Find("Kill").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel4 = go.transform.Find("Death").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel5 = go.transform.Find("Point").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel6 = go.transform.Find("Rank").GetComponent("XUILabel") as IXUILabel;
			ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon(data.RoleProf));
			ixuisprite2.SetAlpha((float)(data.isMVP ? 1 : 0));
			ixuilabel.SetText(data.Name);
			ixuilabel2.SetText(data.ServerName);
			ixuilabel3.SetText(data.KillCount.ToString());
			ixuilabel4.SetText(data.DeathCount.ToString());
			ixuilabel5.SetText(data.Point.ToString());
			ixuilabel6.SetText(data.Rank.ToString());
		}

		// Token: 0x06009EE7 RID: 40679 RVA: 0x001A3BD8 File Offset: 0x001A1DD8
		private void SetupBattleDataUI()
		{
			XLevelRewardDocument.BattleFieldData battleFieldBattleData = this.doc.BattleFieldBattleData;
			this.m_BattleDataPool.ReturnAll(false);
			Vector3 vector = this.m_BattleDataPool.TplPos;
			for (int i = 0; i < battleFieldBattleData.MemberData.Count; i++)
			{
				GameObject gameObject = this.m_BattleDataPool.FetchGameObject(false);
				gameObject.transform.localPosition = vector;
				vector += new Vector3(0f, (float)(-(float)this.m_BattleDataPool.TplHeight));
				IXUISprite ixuisprite = gameObject.transform.Find("Detail/Avatar").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = gameObject.transform.Find("Detail/Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = gameObject.transform.Find("Detail/ServerName").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = gameObject.transform.Find("Profession").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = gameObject.transform.Find("KillTotal").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel5 = gameObject.transform.Find("MaxKill").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel6 = gameObject.transform.Find("DeathCount").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel7 = gameObject.transform.Find("DamageTotal").GetComponent("XUILabel") as IXUILabel;
				ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon(battleFieldBattleData.MemberData[i].RoleProf));
				ixuilabel.SetText(battleFieldBattleData.MemberData[i].Name);
				ixuilabel2.SetText(battleFieldBattleData.MemberData[i].ServerName);
				ixuilabel3.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfName(battleFieldBattleData.MemberData[i].RoleProf));
				IXUILabel ixuilabel8 = ixuilabel4;
				XLevelRewardDocument.BattleRankRoleInfo battleRankRoleInfo = battleFieldBattleData.MemberData[i];
				ixuilabel8.SetText(battleRankRoleInfo.KillCount.ToString());
				IXUILabel ixuilabel9 = ixuilabel5;
				battleRankRoleInfo = battleFieldBattleData.MemberData[i];
				ixuilabel9.SetText(battleRankRoleInfo.CombKill.ToString());
				IXUILabel ixuilabel10 = ixuilabel6;
				battleRankRoleInfo = battleFieldBattleData.MemberData[i];
				ixuilabel10.SetText(battleRankRoleInfo.DeathCount.ToString());
				ixuilabel7.SetText(XSingleton<UiUtility>.singleton.NumberFormat(battleFieldBattleData.MemberData[i].Damage));
			}
		}

		// Token: 0x04003894 RID: 14484
		private XLevelRewardDocument doc = null;

		// Token: 0x04003895 RID: 14485
		private IXUIButton m_BattleDataButton;

		// Token: 0x04003896 RID: 14486
		private IXUIButton m_ReturnButton;

		// Token: 0x04003897 RID: 14487
		private IXUIButton m_ReturnWaitButton;

		// Token: 0x04003898 RID: 14488
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003899 RID: 14489
		private XUIPool m_PlayerPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400389A RID: 14490
		private Transform m_PVPDataFrame;

		// Token: 0x0400389B RID: 14491
		private IXUIButton m_BattleDataCloseButton;

		// Token: 0x0400389C RID: 14492
		private XUIPool m_BattleDataPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
