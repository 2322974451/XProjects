using System;
using UILib;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class BattleDpsHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_uiInfo = (base.PanelObject.GetComponent("XUILabel") as IXUILabel);
			this.m_uiBg = (base.PanelObject.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite);
			this.doc = XDocuments.GetSpecificDocument<XCombatStatisticsDocument>(XCombatStatisticsDocument.uuID);
			this.doc.DpsHandler = this;
			this.m_Dps = 0UL;
			this.m_Rank = 0;
			this.m_strTemplate = XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("DPS_INFO"));
		}

		public override void OnUnload()
		{
			base.OnUnload();
			this.doc.DpsHandler = null;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._Refresh();
			this.RefreshData();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = !XSingleton<XGame>.singleton.SyncMode;
			if (flag)
			{
				this.RefreshData();
			}
		}

		public override void RefreshData()
		{
			base.RefreshData();
			this.doc.ReqDps();
		}

		public void SetDps(double dps, double rank)
		{
			ulong num = (ulong)dps;
			int num2 = (int)rank;
			bool flag = num != this.m_Dps || num2 != this.m_Rank;
			if (flag)
			{
				this.m_Dps = num;
				this.m_Rank = num2;
				this._Refresh();
			}
		}

		public void SetInfo(string s)
		{
			this.m_uiInfo.SetText(s);
			this.m_uiBg.UpdateAnchors();
		}

		private void _Refresh()
		{
			string text = string.Format(this.m_strTemplate, XSingleton<UiUtility>.singleton.NumberFormat(this.m_Dps), this.m_Rank.ToString());
			this.m_uiInfo.SetText(text);
			this.m_uiBg.UpdateAnchors();
		}

		private IXUILabel m_uiInfo;

		private IXUISprite m_uiBg;

		private ulong m_Dps;

		private int m_Rank;

		private XCombatStatisticsDocument doc;

		private string m_strTemplate;
	}
}
