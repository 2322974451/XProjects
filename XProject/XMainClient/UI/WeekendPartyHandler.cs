using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class WeekendPartyHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/WeekendPartyBattleDlg";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_Doc = XDocuments.GetSpecificDocument<XWeekendPartyDocument>(XWeekendPartyDocument.uuID);
			this.m_Doc.WeekendPartyBattleHandler = this;
			this.m_BlueScore = (base.PanelObject.transform.FindChild("Battle/Score/Bluenum").GetComponent("XUILabel") as IXUILabel);
			this.m_RedScore = (base.PanelObject.transform.FindChild("Battle/Score/Rednum").GetComponent("XUILabel") as IXUILabel);
			this.m_ReviveTime = (base.PanelObject.transform.FindChild("LeftTime").GetComponent("XUILabel") as IXUILabel);
			this.m_LeftTimeCounter = new XLeftTimeCounter(this.m_ReviveTime, true);
			this.m_LeftTimeCounter.SetFormat(false);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		public override void OnUnload()
		{
			this.m_Doc.WeekendPartyBattleHandler = null;
			base.OnUnload();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshWeekendPartyBattleData();
			this.SetLeftTime();
		}

		private void SetLeftTime()
		{
			WeekEnd4v4List.RowData activityInfo = this.m_Doc.GetActivityInfo(this.m_Doc.CurrActID);
			bool flag = activityInfo != null;
			if (flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLeftTime(activityInfo.MaxTime, -1);
				}
			}
		}

		public void RefreshWeekendPartyBattleData()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_CRAZYBOMB || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE;
			if (flag)
			{
				this.m_BlueScore.SetText(this.m_Doc.EnemyScore.ToString());
				this.m_RedScore.SetText(this.m_Doc.SelfScore.ToString());
			}
			else
			{
				this.m_BlueScore.SetText(this.m_Doc.SelfScore.ToString());
				this.m_RedScore.SetText(this.m_Doc.EnemyScore.ToString());
			}
		}

		public void ShowReviveUI(uint time)
		{
			this.m_LeftTimeCounter.SetLeftTime(time, -1);
		}

		public override void OnUpdate()
		{
			this.m_LeftTimeCounter.Update();
		}

		private XWeekendPartyDocument m_Doc;

		private IXUILabel m_BlueScore;

		private IXUILabel m_RedScore;

		private IXUILabel m_ReviveTime;

		private XLeftTimeCounter m_LeftTimeCounter;
	}
}
