using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A23 RID: 2595
	internal class LevelRewardBattleRoyaleHandler : DlgHandlerBase
	{
		// Token: 0x17002EC6 RID: 11974
		// (get) Token: 0x06009E9B RID: 40603 RVA: 0x001A1774 File Offset: 0x0019F974
		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardBattleRoyaleFrame";
			}
		}

		// Token: 0x06009E9C RID: 40604 RVA: 0x001A178B File Offset: 0x0019F98B
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.InitUI();
		}

		// Token: 0x06009E9D RID: 40605 RVA: 0x001A17AC File Offset: 0x0019F9AC
		private void InitUI()
		{
			this.m_Win = base.PanelObject.transform.Find("Bg/Result/Win");
			this.m_Fail = base.PanelObject.transform.Find("Bg/Result/Fail");
			this.m_Rank = (base.PanelObject.transform.Find("Bg/Detail/Rank").GetComponent("XUILabel") as IXUILabel);
			this.m_Kill = (base.PanelObject.transform.Find("Bg/Detail/Kill").GetComponent("XUILabel") as IXUILabel);
			this.m_KillBy = (base.PanelObject.transform.Find("Bg/Detail/KillBy").GetComponent("XUILabel") as IXUILabel);
			this.m_LiveTime = (base.PanelObject.transform.Find("Bg/Detail/JS/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_Score = (base.PanelObject.transform.Find("Bg/Detail/JS/Score").GetComponent("XUILabel") as IXUILabel);
			this.m_Tip = (base.PanelObject.transform.Find("Bg/Detail/Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_Button = (base.PanelObject.transform.Find("Bg/Button/Back").GetComponent("XUIButton") as IXUIButton);
			this.m_Button.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnButtonClicked));
		}

		// Token: 0x06009E9E RID: 40606 RVA: 0x001A1930 File Offset: 0x0019FB30
		private bool OnButtonClicked(IXUIButton button)
		{
			this.doc.SendLeaveScene();
			return true;
		}

		// Token: 0x06009E9F RID: 40607 RVA: 0x001A194F File Offset: 0x0019FB4F
		protected override void OnShow()
		{
			base.OnShow();
			this.ShowUI();
		}

		// Token: 0x06009EA0 RID: 40608 RVA: 0x001A1960 File Offset: 0x0019FB60
		private void ShowUI()
		{
			this.m_Win.gameObject.SetActive(this.doc.BattleRoyaleDataInfo.SelfRank == 1U);
			this.m_Fail.gameObject.SetActive(this.doc.BattleRoyaleDataInfo.SelfRank != 1U);
			this.m_Rank.SetText(XStringDefineProxy.GetString("BattleRoyaleRank", new object[]
			{
				this.doc.BattleRoyaleDataInfo.SelfRank,
				this.doc.BattleRoyaleDataInfo.AllRank
			}));
			this.m_Kill.SetText(XStringDefineProxy.GetString("BattleRoyaleKill", new object[]
			{
				this.doc.BattleRoyaleDataInfo.KillCount
			}));
			this.m_KillBy.SetText((this.doc.BattleRoyaleDataInfo.SelfRank != 1U) ? XStringDefineProxy.GetString("BattleRoyaleKilledBy", new object[]
			{
				this.doc.BattleRoyaleDataInfo.KilledBy
			}) : "");
			this.m_LiveTime.SetText(XSingleton<UiUtility>.singleton.TimeFormatString(this.doc.BattleRoyaleDataInfo.LiveTime, 2, 3, 4, false));
			this.m_Score.SetText(this.doc.BattleRoyaleDataInfo.AddPoint.ToString());
			this.m_Tip.SetText((this.doc.BattleRoyaleDataInfo.SelfRank == 1U) ? XStringDefineProxy.GetString("BattleRoyaleWin") : XStringDefineProxy.GetString("BattleRoyaleFail"));
		}

		// Token: 0x04003856 RID: 14422
		private XLevelRewardDocument doc = null;

		// Token: 0x04003857 RID: 14423
		private Transform m_Win;

		// Token: 0x04003858 RID: 14424
		private Transform m_Fail;

		// Token: 0x04003859 RID: 14425
		private IXUILabel m_Rank;

		// Token: 0x0400385A RID: 14426
		private IXUILabel m_Kill;

		// Token: 0x0400385B RID: 14427
		private IXUILabel m_KillBy;

		// Token: 0x0400385C RID: 14428
		private IXUILabel m_LiveTime;

		// Token: 0x0400385D RID: 14429
		private IXUILabel m_Score;

		// Token: 0x0400385E RID: 14430
		private IXUILabel m_Tip;

		// Token: 0x0400385F RID: 14431
		private IXUIButton m_Button;
	}
}
