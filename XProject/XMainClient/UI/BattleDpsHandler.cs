using System;
using UILib;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001733 RID: 5939
	internal class BattleDpsHandler : DlgHandlerBase
	{
		// Token: 0x0600F543 RID: 62787 RVA: 0x00375E34 File Offset: 0x00374034
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

		// Token: 0x0600F544 RID: 62788 RVA: 0x00375ED3 File Offset: 0x003740D3
		public override void OnUnload()
		{
			base.OnUnload();
			this.doc.DpsHandler = null;
		}

		// Token: 0x0600F545 RID: 62789 RVA: 0x00375EE9 File Offset: 0x003740E9
		protected override void OnShow()
		{
			base.OnShow();
			this._Refresh();
			this.RefreshData();
		}

		// Token: 0x0600F546 RID: 62790 RVA: 0x00375F04 File Offset: 0x00374104
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = !XSingleton<XGame>.singleton.SyncMode;
			if (flag)
			{
				this.RefreshData();
			}
		}

		// Token: 0x0600F547 RID: 62791 RVA: 0x00375F31 File Offset: 0x00374131
		public override void RefreshData()
		{
			base.RefreshData();
			this.doc.ReqDps();
		}

		// Token: 0x0600F548 RID: 62792 RVA: 0x00375F48 File Offset: 0x00374148
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

		// Token: 0x0600F549 RID: 62793 RVA: 0x00375F8F File Offset: 0x0037418F
		public void SetInfo(string s)
		{
			this.m_uiInfo.SetText(s);
			this.m_uiBg.UpdateAnchors();
		}

		// Token: 0x0600F54A RID: 62794 RVA: 0x00375FAC File Offset: 0x003741AC
		private void _Refresh()
		{
			string text = string.Format(this.m_strTemplate, XSingleton<UiUtility>.singleton.NumberFormat(this.m_Dps), this.m_Rank.ToString());
			this.m_uiInfo.SetText(text);
			this.m_uiBg.UpdateAnchors();
		}

		// Token: 0x04006A3D RID: 27197
		private IXUILabel m_uiInfo;

		// Token: 0x04006A3E RID: 27198
		private IXUISprite m_uiBg;

		// Token: 0x04006A3F RID: 27199
		private ulong m_Dps;

		// Token: 0x04006A40 RID: 27200
		private int m_Rank;

		// Token: 0x04006A41 RID: 27201
		private XCombatStatisticsDocument doc;

		// Token: 0x04006A42 RID: 27202
		private string m_strTemplate;
	}
}
