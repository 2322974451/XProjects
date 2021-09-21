using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018A7 RID: 6311
	internal class XGuildLogView : DlgHandlerBase
	{
		// Token: 0x17003A12 RID: 14866
		// (set) Token: 0x06010716 RID: 67350 RVA: 0x004059B7 File Offset: 0x00403BB7
		public ILogSource LogSource
		{
			set
			{
				this.m_LogSource = value;
			}
		}

		// Token: 0x06010717 RID: 67351 RVA: 0x004059C4 File Offset: 0x00403BC4
		protected override void Init()
		{
			this.m_ScrollView = (base.PanelObject.transform.FindChild("LogMenu/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.PanelObject.transform.FindChild("LogMenu/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._WrapContentItemUpdated));
		}

		// Token: 0x06010718 RID: 67352 RVA: 0x00405A40 File Offset: 0x00403C40
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			Transform transform = base.PanelObject.transform.FindChild("Close");
			bool flag = transform != null;
			if (flag)
			{
				IXUIButton ixuibutton = transform.GetComponent("XUIButton") as IXUIButton;
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			}
		}

		// Token: 0x06010719 RID: 67353 RVA: 0x00405A9C File Offset: 0x00403C9C
		public void Refresh()
		{
			List<ILogData> logList = this.m_LogSource.GetLogList();
			int count = logList.Count;
			this.m_WrapContent.SetContentCount(count, false);
			this.m_ScrollView.ResetPosition();
		}

		// Token: 0x0601071A RID: 67354 RVA: 0x00405AD8 File Offset: 0x00403CD8
		private void _WrapContentItemUpdated(Transform t, int index)
		{
			List<ILogData> logList = this.m_LogSource.GetLogList();
			bool flag = index < 0 || index >= logList.Count;
			if (!flag)
			{
				ILogData logData = logList[index];
				IXUILabelSymbol ixuilabelSymbol = t.FindChild("Content").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				IXUILabel ixuilabel = t.FindChild("Time").GetComponent("XUILabel") as IXUILabel;
				ixuilabelSymbol.RegisterNameEventHandler(new HyperLinkClickEventHandler(this._NameClick));
				ixuilabelSymbol.InputText = logData.GetContent();
				ixuilabel.SetText(logData.GetTime());
			}
		}

		// Token: 0x0601071B RID: 67355 RVA: 0x00405B78 File Offset: 0x00403D78
		private bool _OnCloseBtnClick(IXUIButton go)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0601071C RID: 67356 RVA: 0x00405B94 File Offset: 0x00403D94
		private void _NameClick(string param)
		{
			string text = "";
			ulong num = 0UL;
			bool flag = XLabelSymbolHelper.ParseNameParam(param, ref text, ref num);
			if (flag)
			{
				bool flag2 = num == XSingleton<XEntityMgr>.singleton.Player.Attributes.EntityID;
				if (!flag2)
				{
					XCharacterCommonMenuDocument.ReqCharacterMenuInfo(num, false);
				}
			}
		}

		// Token: 0x040076CA RID: 30410
		private ILogSource m_LogSource;

		// Token: 0x040076CB RID: 30411
		private IXUIWrapContent m_WrapContent;

		// Token: 0x040076CC RID: 30412
		private IXUIScrollView m_ScrollView;
	}
}
