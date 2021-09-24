using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardBattleFieldHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardBattleFieldFrame";
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
			this.m_PlayerPool.SetupPool(null, base.transform.Find("Bg/Rank/Rank/Panel/PlayerTpl").gameObject, 8U, false);
			this.m_ItemPool.SetupPool(null, base.transform.Find("Bg/Bottom/ItemList/Panel/ItemTpl").gameObject, 5U, false);
			this.m_BattleDataButton = (base.transform.Find("Bg/Bottom/BattleData").GetComponent("XUIButton") as IXUIButton);
			this.m_ReturnButton = (base.transform.Find("Bg/Bottom/Return").GetComponent("XUIButton") as IXUIButton);
			this.m_ReturnWaitButton = (base.transform.Find("Bg/Bottom/ReturnWait").GetComponent("XUIButton") as IXUIButton);
		}

		private void InitDetailUI()
		{
			this.m_PVPDataFrame = base.PanelObject.transform.Find("Bg/PVPDataFrame");
			this.m_BattleDataPool.SetupPool(null, this.m_PVPDataFrame.Find("Panel/MemberTpl").gameObject, 8U, false);
			this.m_BattleDataCloseButton = (this.m_PVPDataFrame.Find("Close").GetComponent("XUIButton") as IXUIButton);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BattleDataButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBattleDataButtonClicked));
			this.m_ReturnButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnButtonClicked));
			this.m_ReturnWaitButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnWaitButtonClicked));
			this.m_BattleDataCloseButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnDetailCloseButtonClicked));
		}

		private bool OnBattleDataButtonClicked(IXUIButton button)
		{
			this.m_PVPDataFrame.gameObject.SetActive(true);
			return true;
		}

		private bool OnReturnButtonClicked(IXUIButton button)
		{
			this.doc.SendLeaveScene();
			return true;
		}

		private bool OnReturnWaitButtonClicked(IXUIButton button)
		{
			this.doc.SendReturnWaitBattleField();
			return true;
		}

		private bool OnDetailCloseButtonClicked(IXUIButton button)
		{
			this.m_PVPDataFrame.gameObject.SetActive(false);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.OnShowUI();
			this.SetupBattleDataUI();
		}

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

		private XLevelRewardDocument doc = null;

		private IXUIButton m_BattleDataButton;

		private IXUIButton m_ReturnButton;

		private IXUIButton m_ReturnWaitButton;

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_PlayerPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Transform m_PVPDataFrame;

		private IXUIButton m_BattleDataCloseButton;

		private XUIPool m_BattleDataPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
