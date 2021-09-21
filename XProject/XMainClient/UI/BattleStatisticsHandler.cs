using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016D3 RID: 5843
	internal class BattleStatisticsHandler : DlgHandlerBase
	{
		// Token: 0x1700373F RID: 14143
		// (get) Token: 0x0600F0FF RID: 61695 RVA: 0x003521C0 File Offset: 0x003503C0
		protected override string FileName
		{
			get
			{
				return "Battle/BattleStatistics";
			}
		}

		// Token: 0x0600F100 RID: 61696 RVA: 0x003521D8 File Offset: 0x003503D8
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XCombatStatisticsDocument>(XCombatStatisticsDocument.uuID);
			this.doc.StatisticsHandler = this;
			this.m_ScrollView = (base.PanelObject.transform.Find("Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (this.m_ScrollView.gameObject.transform.Find("WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_Total = (base.PanelObject.transform.Find("Bg/Total").GetComponent("XUILabel") as IXUILabel);
			this.m_HelpFrame = base.PanelObject.transform.Find("Bg/HelpsFrame").gameObject;
			this.m_LabelHelp = (this.m_HelpFrame.transform.Find("Helps").GetComponent("XUILabel") as IXUILabel);
			this.m_LabelHelp.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("BATTLE_STATISTICS_HELP")));
			this.m_BtnHelp = (base.PanelObject.transform.Find("Bg/BtnHelp").GetComponent("XUISprite") as IXUISprite);
			this.m_BtnReset = (base.PanelObject.transform.Find("Bg/BtnReset").GetComponent("XUISprite") as IXUISprite);
			this.m_HelpFrame.SetActive(false);
		}

		// Token: 0x0600F101 RID: 61697 RVA: 0x00352357 File Offset: 0x00350557
		public override void OnUnload()
		{
			base.OnUnload();
			this.doc.StatisticsHandler = null;
		}

		// Token: 0x0600F102 RID: 61698 RVA: 0x00352370 File Offset: 0x00350570
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._WrapContentItemUpdated));
			this.m_BtnHelp.RegisterSpritePressEventHandler(new SpritePressEventHandler(this._OnHelpClicked));
			this.m_BtnReset.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnResetClicked));
		}

		// Token: 0x0600F103 RID: 61699 RVA: 0x003523D0 File Offset: 0x003505D0
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor != null;
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.TemporarilyHide(true);
			}
		}

		// Token: 0x0600F104 RID: 61700 RVA: 0x00352420 File Offset: 0x00350620
		protected override void OnHide()
		{
			base.OnHide();
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor != null;
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.TemporarilyHide(false);
			}
		}

		// Token: 0x0600F105 RID: 61701 RVA: 0x00352468 File Offset: 0x00350668
		public override void OnUpdate()
		{
			base.OnUpdate();
			float time = Time.time;
			bool flag = time - this.m_Timer > BattleStatisticsHandler.REFRESH_INTERVAL;
			if (flag)
			{
				this.m_Timer = time;
				this.doc.ReqStatistics();
			}
		}

		// Token: 0x0600F106 RID: 61702 RVA: 0x003524AC File Offset: 0x003506AC
		public override void RefreshData()
		{
			base.RefreshData();
			this.m_WrapContent.SetContentCount(this.doc.StatisticsList.Count, false);
			this.m_Total.SetText(XSingleton<UiUtility>.singleton.NumberFormat((ulong)this.doc.TotalDamage));
		}

		// Token: 0x0600F107 RID: 61703 RVA: 0x00352500 File Offset: 0x00350700
		private void _WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this.doc.StatisticsList.Count;
			if (!flag)
			{
				XCombatStatisticsInfo xcombatStatisticsInfo = this.doc.StatisticsList[index];
				bool flag2 = xcombatStatisticsInfo == null;
				if (!flag2)
				{
					IXUILabel ixuilabel = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel2 = t.Find("Count").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel3 = t.Find("Value").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel4 = t.Find("Percentage").GetComponent("XUILabel") as IXUILabel;
					ulong num = (ulong)xcombatStatisticsInfo.value;
					ixuilabel.SetText(xcombatStatisticsInfo.name);
					bool flag3 = xcombatStatisticsInfo.count > 999;
					if (flag3)
					{
						ixuilabel2.SetText("...");
					}
					else
					{
						bool flag4 = num != 0UL && xcombatStatisticsInfo.count == 0;
						if (flag4)
						{
							ixuilabel2.SetText("1");
						}
						else
						{
							ixuilabel2.SetText(xcombatStatisticsInfo.count.ToString());
						}
					}
					ixuilabel3.SetText(XSingleton<UiUtility>.singleton.NumberFormat(num));
					ixuilabel4.SetText(string.Format("{0}%", (int)(xcombatStatisticsInfo.percent * 100f)));
				}
			}
		}

		// Token: 0x0600F108 RID: 61704 RVA: 0x0035266C File Offset: 0x0035086C
		private bool _OnHelpClicked(IXUISprite iSp, bool isPressed)
		{
			this.m_HelpFrame.SetActive(isPressed);
			return true;
		}

		// Token: 0x0600F109 RID: 61705 RVA: 0x0035268C File Offset: 0x0035088C
		private void _OnResetClicked(IXUISprite iSp)
		{
			this.doc.ResetStatistics();
			this.doc.ReqStatistics();
		}

		// Token: 0x040066E0 RID: 26336
		private XCombatStatisticsDocument doc;

		// Token: 0x040066E1 RID: 26337
		private IXUIScrollView m_ScrollView;

		// Token: 0x040066E2 RID: 26338
		private IXUIWrapContent m_WrapContent;

		// Token: 0x040066E3 RID: 26339
		private IXUILabel m_Total;

		// Token: 0x040066E4 RID: 26340
		private IXUISprite m_BtnHelp;

		// Token: 0x040066E5 RID: 26341
		private IXUISprite m_BtnReset;

		// Token: 0x040066E6 RID: 26342
		private GameObject m_HelpFrame;

		// Token: 0x040066E7 RID: 26343
		private IXUILabel m_LabelHelp;

		// Token: 0x040066E8 RID: 26344
		private float m_Timer = 0f;

		// Token: 0x040066E9 RID: 26345
		private static float REFRESH_INTERVAL = 1f;
	}
}
