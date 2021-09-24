using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XCommonHelpTipView : DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>
	{

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override string fileName
		{
			get
			{
				return "Common/CommonHelpTip";
			}
		}

		public void ShowHelp(string title, string content)
		{
			this.m_title = title;
			this.m_content = XSingleton<UiUtility>.singleton.ReplaceReturn(content);
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisibleWithAnimation(true, null);
			}
		}

		public void ShowHelp(int sysID)
		{
			bool flag = this._systemHelpReader == null;
			if (flag)
			{
				this._systemHelpReader = new SystemHelpTable();
				XSingleton<XResourceLoaderMgr>.singleton.ReadFile("Table/SystemHelp", this._systemHelpReader);
			}
			SystemHelpTable.RowData bySystemID = this._systemHelpReader.GetBySystemID(sysID);
			bool flag2 = bySystemID != null;
			if (flag2)
			{
				bool flag3 = bySystemID.SystemHelp != null && bySystemID.SystemHelp.Length != 0;
				if (flag3)
				{
					this.m_title = bySystemID.SystemHelp[0];
				}
				bool flag4 = bySystemID.SystemHelp != null && bySystemID.SystemHelp.Length > 1;
				if (flag4)
				{
					this.m_content = XSingleton<UiUtility>.singleton.ReplaceReturn(bySystemID.SystemHelp[1]);
				}
			}
			bool flag5 = !base.IsVisible();
			if (flag5)
			{
				this.SetVisibleWithAnimation(true, null);
			}
		}

		public void ShowHelp(XSysDefine sys)
		{
			this.m_title = "";
			this.m_content = "";
			bool flag = this._systemHelpReader == null;
			if (flag)
			{
				this._systemHelpReader = new SystemHelpTable();
				XSingleton<XResourceLoaderMgr>.singleton.ReadFile("Table/SystemHelp", this._systemHelpReader);
			}
			int key = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(sys);
			SystemHelpTable.RowData bySystemID = this._systemHelpReader.GetBySystemID(key);
			bool flag2 = bySystemID != null;
			if (flag2)
			{
				bool flag3 = bySystemID.SystemHelp != null && bySystemID.SystemHelp.Length != 0;
				if (flag3)
				{
					this.m_title = bySystemID.SystemHelp[0];
				}
				bool flag4 = bySystemID.SystemHelp != null && bySystemID.SystemHelp.Length > 1;
				if (flag4)
				{
					this.m_content = XSingleton<UiUtility>.singleton.ReplaceReturn(bySystemID.SystemHelp[1]);
				}
			}
			bool flag5 = !base.IsVisible();
			if (flag5)
			{
				this.SetVisibleWithAnimation(true, null);
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_Title.SetText(this.m_title);
			base.uiBehaviour.m_Content.SetText(this.m_content);
			base.uiBehaviour.m_ScrollView.ResetPosition();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClicked));
		}

		private bool OnCloseBtnClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

		private SystemHelpTable _systemHelpReader = null;

		private string m_title;

		private string m_content;
	}
}
