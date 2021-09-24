using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGuildLogView : DlgHandlerBase
	{

		public ILogSource LogSource
		{
			set
			{
				this.m_LogSource = value;
			}
		}

		protected override void Init()
		{
			this.m_ScrollView = (base.PanelObject.transform.FindChild("LogMenu/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.PanelObject.transform.FindChild("LogMenu/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._WrapContentItemUpdated));
		}

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

		public void Refresh()
		{
			List<ILogData> logList = this.m_LogSource.GetLogList();
			int count = logList.Count;
			this.m_WrapContent.SetContentCount(count, false);
			this.m_ScrollView.ResetPosition();
		}

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

		private bool _OnCloseBtnClick(IXUIButton go)
		{
			base.SetVisible(false);
			return true;
		}

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

		private ILogSource m_LogSource;

		private IXUIWrapContent m_WrapContent;

		private IXUIScrollView m_ScrollView;
	}
}
