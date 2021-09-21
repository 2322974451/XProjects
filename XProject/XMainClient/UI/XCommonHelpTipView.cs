using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200187B RID: 6267
	internal class XCommonHelpTipView : DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>
	{
		// Token: 0x170039C8 RID: 14792
		// (get) Token: 0x060104EE RID: 66798 RVA: 0x003F24A4 File Offset: 0x003F06A4
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170039C9 RID: 14793
		// (get) Token: 0x060104EF RID: 66799 RVA: 0x003F24B8 File Offset: 0x003F06B8
		public override string fileName
		{
			get
			{
				return "Common/CommonHelpTip";
			}
		}

		// Token: 0x060104F0 RID: 66800 RVA: 0x003F24D0 File Offset: 0x003F06D0
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

		// Token: 0x060104F1 RID: 66801 RVA: 0x003F2510 File Offset: 0x003F0710
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

		// Token: 0x060104F2 RID: 66802 RVA: 0x003F25DC File Offset: 0x003F07DC
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

		// Token: 0x060104F3 RID: 66803 RVA: 0x003F26C8 File Offset: 0x003F08C8
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_Title.SetText(this.m_title);
			base.uiBehaviour.m_Content.SetText(this.m_content);
			base.uiBehaviour.m_ScrollView.ResetPosition();
		}

		// Token: 0x060104F4 RID: 66804 RVA: 0x003F271C File Offset: 0x003F091C
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClicked));
		}

		// Token: 0x060104F5 RID: 66805 RVA: 0x003F2744 File Offset: 0x003F0944
		private bool OnCloseBtnClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

		// Token: 0x04007551 RID: 30033
		private SystemHelpTable _systemHelpReader = null;

		// Token: 0x04007552 RID: 30034
		private string m_title;

		// Token: 0x04007553 RID: 30035
		private string m_content;
	}
}
