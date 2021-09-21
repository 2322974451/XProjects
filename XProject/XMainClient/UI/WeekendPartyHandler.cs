using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001734 RID: 5940
	internal class WeekendPartyHandler : DlgHandlerBase
	{
		// Token: 0x170037BB RID: 14267
		// (get) Token: 0x0600F54C RID: 62796 RVA: 0x00375FFC File Offset: 0x003741FC
		protected override string FileName
		{
			get
			{
				return "Battle/WeekendPartyBattleDlg";
			}
		}

		// Token: 0x0600F54D RID: 62797 RVA: 0x00376014 File Offset: 0x00374214
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

		// Token: 0x0600F54E RID: 62798 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600F54F RID: 62799 RVA: 0x003760E2 File Offset: 0x003742E2
		public override void OnUnload()
		{
			this.m_Doc.WeekendPartyBattleHandler = null;
			base.OnUnload();
		}

		// Token: 0x0600F550 RID: 62800 RVA: 0x003760F8 File Offset: 0x003742F8
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshWeekendPartyBattleData();
			this.SetLeftTime();
		}

		// Token: 0x0600F551 RID: 62801 RVA: 0x00376110 File Offset: 0x00374310
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

		// Token: 0x0600F552 RID: 62802 RVA: 0x00376170 File Offset: 0x00374370
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

		// Token: 0x0600F553 RID: 62803 RVA: 0x00376223 File Offset: 0x00374423
		public void ShowReviveUI(uint time)
		{
			this.m_LeftTimeCounter.SetLeftTime(time, -1);
		}

		// Token: 0x0600F554 RID: 62804 RVA: 0x00376236 File Offset: 0x00374436
		public override void OnUpdate()
		{
			this.m_LeftTimeCounter.Update();
		}

		// Token: 0x04006A43 RID: 27203
		private XWeekendPartyDocument m_Doc;

		// Token: 0x04006A44 RID: 27204
		private IXUILabel m_BlueScore;

		// Token: 0x04006A45 RID: 27205
		private IXUILabel m_RedScore;

		// Token: 0x04006A46 RID: 27206
		private IXUILabel m_ReviveTime;

		// Token: 0x04006A47 RID: 27207
		private XLeftTimeCounter m_LeftTimeCounter;
	}
}
