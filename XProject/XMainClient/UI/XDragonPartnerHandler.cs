using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	internal class XDragonPartnerHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/DragonPartnerFrame";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._ApplyTabData(this.m_CurrentTabIndex);
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

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

		private XDragonPartnerDocument m_doc;

		private XDragonPartnerHandler.TabIndex m_CurrentTabIndex = XDragonPartnerHandler.TabIndex.Record;

		private XDragonRecordHandler m_DragonRecordHandler;

		private XDragonHistoryHandler m_DragonHistoryHandler;

		private IXUICheckBox m_Tab0;

		private IXUICheckBox m_Tab1;

		private GameObject m_RecordFrame;

		private GameObject m_HistoryFrame;

		private enum TabIndex
		{

			Record,

			History,

			Max
		}
	}
}
