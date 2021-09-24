using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardBattleRoyaleHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardBattleRoyaleFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.InitUI();
		}

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

		private bool OnButtonClicked(IXUIButton button)
		{
			this.doc.SendLeaveScene();
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.ShowUI();
		}

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

		private XLevelRewardDocument doc = null;

		private Transform m_Win;

		private Transform m_Fail;

		private IXUILabel m_Rank;

		private IXUILabel m_Kill;

		private IXUILabel m_KillBy;

		private IXUILabel m_LiveTime;

		private IXUILabel m_Score;

		private IXUILabel m_Tip;

		private IXUIButton m_Button;
	}
}
