using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BAB RID: 2987
	internal class LevelRewardSuperRiskFailHandler : DlgHandlerBase
	{
		// Token: 0x17003050 RID: 12368
		// (get) Token: 0x0600AB48 RID: 43848 RVA: 0x001F30C4 File Offset: 0x001F12C4
		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardSuperRiskFail";
			}
		}

		// Token: 0x0600AB49 RID: 43849 RVA: 0x001F30DB File Offset: 0x001F12DB
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.InitUI();
		}

		// Token: 0x0600AB4A RID: 43850 RVA: 0x001F30FC File Offset: 0x001F12FC
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

		// Token: 0x0600AB4B RID: 43851 RVA: 0x001F3238 File Offset: 0x001F1438
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_ReturnButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnButtonClicked));
			this.m_GuildMineReturnButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnButtonClicked));
			this.m_ChallengeAgainButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnChallengeAgainButtonClicked));
		}

		// Token: 0x0600AB4C RID: 43852 RVA: 0x001F3298 File Offset: 0x001F1498
		private bool OnReturnButtonClicked(IXUIButton button)
		{
			this._doc.SendLeaveScene();
			return true;
		}

		// Token: 0x0600AB4D RID: 43853 RVA: 0x001F32B8 File Offset: 0x001F14B8
		private bool OnChallengeAgainButtonClicked(IXUIButton button)
		{
			this._doc.SendReEnterRiskBattle();
			return true;
		}

		// Token: 0x0600AB4E RID: 43854 RVA: 0x001F32D8 File Offset: 0x001F14D8
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

		// Token: 0x0400400F RID: 16399
		private XLevelRewardDocument _doc = null;

		// Token: 0x04004010 RID: 16400
		private IXUIButton m_ReturnButton;

		// Token: 0x04004011 RID: 16401
		private IXUIButton m_GuildMineReturnButton;

		// Token: 0x04004012 RID: 16402
		private IXUIButton m_ChallengeAgainButton;

		// Token: 0x04004013 RID: 16403
		private IXUILabelSymbol m_CostLabel;

		// Token: 0x04004014 RID: 16404
		private Transform m_SuperRiskLabel;

		// Token: 0x04004015 RID: 16405
		private Transform m_GuildMineLabel;

		// Token: 0x04004016 RID: 16406
		private Transform m_SuperRiskButton;

		// Token: 0x04004017 RID: 16407
		private Transform m_GuildMineButton;
	}
}
