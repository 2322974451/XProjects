using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x020016DE RID: 5854
	internal class XDragonPartnerHandler : DlgHandlerBase
	{
		// Token: 0x17003751 RID: 14161
		// (get) Token: 0x0600F17A RID: 61818 RVA: 0x00355330 File Offset: 0x00353530
		protected override string FileName
		{
			get
			{
				return "GameSystem/DragonPartnerFrame";
			}
		}

		// Token: 0x0600F17B RID: 61819 RVA: 0x00355348 File Offset: 0x00353548
		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XDragonPartnerDocument>(XDragonPartnerDocument.uuID);
			this.m_doc.View = this;
			this.m_Tab0 = (base.PanelObject.transform.Find("padTabs/TabTpl0/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_Tab1 = (base.PanelObject.transform.Find("padTabs/TabTpl1/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_Tab0.ID = 0UL;
			this.m_Tab0.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnClickTab));
			this.m_Tab1.ID = 1UL;
			this.m_Tab1.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnClickTab));
			this.m_RecordFrame = base.PanelObject.transform.Find("DragonNestRecordingFrame").gameObject;
			this.m_HistoryFrame = base.PanelObject.transform.Find("historyFrame").gameObject;
			DlgHandlerBase.EnsureCreate<XDragonRecordHandler>(ref this.m_DragonRecordHandler, this.m_RecordFrame, this, false);
			DlgHandlerBase.EnsureCreate<XDragonHistoryHandler>(ref this.m_DragonHistoryHandler, this.m_HistoryFrame, this, false);
		}

		// Token: 0x0600F17C RID: 61820 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600F17D RID: 61821 RVA: 0x00355481 File Offset: 0x00353681
		protected override void OnShow()
		{
			base.OnShow();
			this._ApplyTabData(this.m_CurrentTabIndex);
		}

		// Token: 0x0600F17E RID: 61822 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600F17F RID: 61823 RVA: 0x00355498 File Offset: 0x00353698
		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XDragonHistoryHandler>(ref this.m_DragonHistoryHandler);
			DlgHandlerBase.EnsureUnload<XDragonRecordHandler>(ref this.m_DragonRecordHandler);
			bool flag = this.m_doc != null;
			if (flag)
			{
				this.m_doc.View = null;
			}
			base.OnUnload();
		}

		// Token: 0x0600F180 RID: 61824 RVA: 0x003554E0 File Offset: 0x003536E0
		private bool OnClickTab(IXUICheckBox cbx)
		{
			bool bChecked = cbx.bChecked;
			if (bChecked)
			{
				this.m_CurrentTabIndex = (XDragonPartnerHandler.TabIndex)cbx.ID;
				this._ApplyTabData(this.m_CurrentTabIndex);
			}
			return true;
		}

		// Token: 0x0600F181 RID: 61825 RVA: 0x0035551C File Offset: 0x0035371C
		private void _ApplyTabData(XDragonPartnerHandler.TabIndex tab)
		{
			bool flag = base.IsVisible();
			bool flag2 = flag;
			if (flag2)
			{
				XDragonPartnerHandler.TabIndex currentTabIndex = this.m_CurrentTabIndex;
				if (currentTabIndex != XDragonPartnerHandler.TabIndex.Record)
				{
					if (currentTabIndex == XDragonPartnerHandler.TabIndex.History)
					{
						this.m_DragonRecordHandler.SetVisible(false);
						this.m_DragonHistoryHandler.SetVisible(true);
					}
				}
				else
				{
					this.m_DragonRecordHandler.SetVisible(true);
					this.m_DragonHistoryHandler.SetVisible(false);
				}
			}
		}

		// Token: 0x0600F182 RID: 61826 RVA: 0x00355588 File Offset: 0x00353788
		public override void RefreshData()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				XDragonPartnerHandler.TabIndex currentTabIndex = this.m_CurrentTabIndex;
				if (currentTabIndex != XDragonPartnerHandler.TabIndex.Record)
				{
					if (currentTabIndex == XDragonPartnerHandler.TabIndex.History)
					{
						bool flag2 = this.m_DragonHistoryHandler.IsVisible();
						if (flag2)
						{
							this.m_DragonHistoryHandler.RefreshData();
						}
					}
				}
				else
				{
					bool flag3 = this.m_DragonRecordHandler.IsVisible();
					if (flag3)
					{
						this.m_DragonRecordHandler.RefreshData();
					}
				}
			}
		}

		// Token: 0x04006731 RID: 26417
		private XDragonPartnerDocument m_doc;

		// Token: 0x04006732 RID: 26418
		private XDragonPartnerHandler.TabIndex m_CurrentTabIndex = XDragonPartnerHandler.TabIndex.Record;

		// Token: 0x04006733 RID: 26419
		private XDragonRecordHandler m_DragonRecordHandler;

		// Token: 0x04006734 RID: 26420
		private XDragonHistoryHandler m_DragonHistoryHandler;

		// Token: 0x04006735 RID: 26421
		private IXUICheckBox m_Tab0;

		// Token: 0x04006736 RID: 26422
		private IXUICheckBox m_Tab1;

		// Token: 0x04006737 RID: 26423
		private GameObject m_RecordFrame;

		// Token: 0x04006738 RID: 26424
		private GameObject m_HistoryFrame;

		// Token: 0x02001A02 RID: 6658
		private enum TabIndex
		{
			// Token: 0x040081F2 RID: 33266
			Record,
			// Token: 0x040081F3 RID: 33267
			History,
			// Token: 0x040081F4 RID: 33268
			Max
		}
	}
}
