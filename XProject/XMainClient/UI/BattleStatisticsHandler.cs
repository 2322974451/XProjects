using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class BattleStatisticsHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/BattleStatistics";
			}
		}

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

		public override void OnUnload()
		{
			base.OnUnload();
			this.doc.StatisticsHandler = null;
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._WrapContentItemUpdated));
			this.m_BtnHelp.RegisterSpritePressEventHandler(new SpritePressEventHandler(this._OnHelpClicked));
			this.m_BtnReset.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnResetClicked));
		}

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

		protected override void OnHide()
		{
			base.OnHide();
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor != null;
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.TemporarilyHide(false);
			}
		}

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

		public override void RefreshData()
		{
			base.RefreshData();
			this.m_WrapContent.SetContentCount(this.doc.StatisticsList.Count, false);
			this.m_Total.SetText(XSingleton<UiUtility>.singleton.NumberFormat((ulong)this.doc.TotalDamage));
		}

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

		private bool _OnHelpClicked(IXUISprite iSp, bool isPressed)
		{
			this.m_HelpFrame.SetActive(isPressed);
			return true;
		}

		private void _OnResetClicked(IXUISprite iSp)
		{
			this.doc.ResetStatistics();
			this.doc.ReqStatistics();
		}

		private XCombatStatisticsDocument doc;

		private IXUIScrollView m_ScrollView;

		private IXUIWrapContent m_WrapContent;

		private IXUILabel m_Total;

		private IXUISprite m_BtnHelp;

		private IXUISprite m_BtnReset;

		private GameObject m_HelpFrame;

		private IXUILabel m_LabelHelp;

		private float m_Timer = 0f;

		private static float REFRESH_INTERVAL = 1f;
	}
}
