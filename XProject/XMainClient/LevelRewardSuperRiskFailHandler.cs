using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardSuperRiskFailHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardSuperRiskFail";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.InitUI();
		}

		private void InitUI()
		{
			this.m_SuperRiskLabel = base.transform.Find("Bg/SuperRisk");
			this.m_GuildMineLabel = base.transform.Find("Bg/GuildMine");
			this.m_SuperRiskButton = base.transform.Find("Bg/Button/SuperRisk");
			this.m_GuildMineButton = base.transform.Find("Bg/Button/GuildMine");
			this.m_ReturnButton = (base.transform.Find("Bg/Button/SuperRisk/Return").GetComponent("XUIButton") as IXUIButton);
			this.m_GuildMineReturnButton = (base.transform.Find("Bg/Button/GuildMine/Return").GetComponent("XUIButton") as IXUIButton);
			this.m_ChallengeAgainButton = (base.transform.Find("Bg/Button/SuperRisk/Continue").GetComponent("XUIButton") as IXUIButton);
			this.m_CostLabel = (base.transform.Find("Bg/Button/SuperRisk/Continue/MoneyCost").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("RiskReBattle", true);
			this.m_CostLabel.InputText = string.Format("{0}{1}", XLabelSymbolHelper.FormatSmallIcon(sequenceList[0, 0]), sequenceList[0, 1]);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_ReturnButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnButtonClicked));
			this.m_GuildMineReturnButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnButtonClicked));
			this.m_ChallengeAgainButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnChallengeAgainButtonClicked));
		}

		private bool OnReturnButtonClicked(IXUIButton button)
		{
			this._doc.SendLeaveScene();
			return true;
		}

		private bool OnChallengeAgainButtonClicked(IXUIButton button)
		{
			this._doc.SendReEnterRiskBattle();
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_RESWAR_PVP || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_RESWAR_PVE;
			if (flag)
			{
				this.m_SuperRiskLabel.gameObject.SetActive(false);
				this.m_SuperRiskButton.gameObject.SetActive(false);
				this.m_GuildMineLabel.gameObject.SetActive(true);
				this.m_GuildMineButton.gameObject.SetActive(true);
				XSingleton<XUICacheMgr>.singleton.RemoveCachedUI(XSysDefine.XSys_Team);
				XGuildMineMainDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
				specificDocument.IsNeedShowMainUI = true;
			}
			else
			{
				this.m_SuperRiskLabel.gameObject.SetActive(true);
				this.m_SuperRiskButton.gameObject.SetActive(true);
				this.m_GuildMineLabel.gameObject.SetActive(false);
				this.m_GuildMineButton.gameObject.SetActive(false);
			}
		}

		private XLevelRewardDocument _doc = null;

		private IXUIButton m_ReturnButton;

		private IXUIButton m_GuildMineReturnButton;

		private IXUIButton m_ChallengeAgainButton;

		private IXUILabelSymbol m_CostLabel;

		private Transform m_SuperRiskLabel;

		private Transform m_GuildMineLabel;

		private Transform m_SuperRiskButton;

		private Transform m_GuildMineButton;
	}
}
