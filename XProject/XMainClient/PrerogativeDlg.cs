using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C6B RID: 3179
	internal class PrerogativeDlg : DlgBase<PrerogativeDlg, PrerogativeDlgBehaviour>
	{
		// Token: 0x170031DA RID: 12762
		// (get) Token: 0x0600B3E5 RID: 46053 RVA: 0x002310D4 File Offset: 0x0022F2D4
		public override string fileName
		{
			get
			{
				return "GameSystem/Welfare/PrerogativeFrame";
			}
		}

		// Token: 0x170031DB RID: 12763
		// (get) Token: 0x0600B3E6 RID: 46054 RVA: 0x002310EC File Offset: 0x0022F2EC
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Prerogative);
			}
		}

		// Token: 0x170031DC RID: 12764
		// (get) Token: 0x0600B3E7 RID: 46055 RVA: 0x00231108 File Offset: 0x0022F308
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170031DD RID: 12765
		// (get) Token: 0x0600B3E8 RID: 46056 RVA: 0x0023111C File Offset: 0x0022F31C
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170031DE RID: 12766
		// (get) Token: 0x0600B3E9 RID: 46057 RVA: 0x00231130 File Offset: 0x0022F330
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170031DF RID: 12767
		// (get) Token: 0x0600B3EA RID: 46058 RVA: 0x00231144 File Offset: 0x0022F344
		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600B3EB RID: 46059 RVA: 0x00231157 File Offset: 0x0022F357
		protected override void OnLoad()
		{
			this._Doc.View = null;
			base.OnLoad();
		}

		// Token: 0x0600B3EC RID: 46060 RVA: 0x0023116D File Offset: 0x0022F36D
		protected override void Init()
		{
			base.Init();
			DlgHandlerBase.EnsureCreate<PreSettingNodeHandler>(ref this._settingHandler, base.uiBehaviour._setting.gameObject, this, false);
		}

		// Token: 0x0600B3ED RID: 46061 RVA: 0x00231198 File Offset: 0x0022F398
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._Doc = XDocuments.GetSpecificDocument<XPrerogativeDocument>(XPrerogativeDocument.uuID);
			this._Doc.View = this;
			base.uiBehaviour._ruleBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnHelpHandler));
			base.uiBehaviour._shopBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.SkipToShop));
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickClose));
		}

		// Token: 0x0600B3EE RID: 46062 RVA: 0x00231220 File Offset: 0x0022F420
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B3EF RID: 46063 RVA: 0x0023122C File Offset: 0x0022F42C
		private bool _OnHelpHandler(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Prerogative);
			return true;
		}

		// Token: 0x0600B3F0 RID: 46064 RVA: 0x0023124F File Offset: 0x0022F44F
		protected override void OnShow()
		{
			base.OnShow();
			this.SetupFadeIn();
		}

		// Token: 0x0600B3F1 RID: 46065 RVA: 0x00231260 File Offset: 0x0022F460
		private bool ClickClose(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

		// Token: 0x0600B3F2 RID: 46066 RVA: 0x0023127C File Offset: 0x0022F47C
		private void SetupFadeIn()
		{
			base.uiBehaviour._desc.SetText(XStringDefineProxy.GetString("XSys_Predesc"));
			bool flag = this._settingHandler != null;
			if (flag)
			{
				bool flag2 = this._settingHandler.IsVisible();
				if (flag2)
				{
					this._settingHandler.RefreshData();
				}
				else
				{
					this._settingHandler.SetVisible(true);
				}
			}
		}

		// Token: 0x0600B3F3 RID: 46067 RVA: 0x002312DE File Offset: 0x0022F4DE
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.Refresh();
		}

		// Token: 0x0600B3F4 RID: 46068 RVA: 0x002312EF File Offset: 0x0022F4EF
		public void Refresh()
		{
			this.SetupSetting();
		}

		// Token: 0x0600B3F5 RID: 46069 RVA: 0x002312F9 File Offset: 0x0022F4F9
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<PreSettingNodeHandler>(ref this._settingHandler);
			base.OnUnload();
		}

		// Token: 0x0600B3F6 RID: 46070 RVA: 0x00231310 File Offset: 0x0022F510
		private void SetupSetting()
		{
			bool flag = this._settingHandler != null && this._settingHandler.IsVisible();
			if (flag)
			{
				this._settingHandler.RefreshData();
			}
		}

		// Token: 0x0600B3F7 RID: 46071 RVA: 0x00231344 File Offset: 0x0022F544
		private bool SkipToShop(IXUIButton btn)
		{
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_PrerogativeShop, 0UL);
			return true;
		}

		// Token: 0x040045C1 RID: 17857
		private XPrerogativeDocument _Doc = null;

		// Token: 0x040045C2 RID: 17858
		private PreSettingNodeHandler _settingHandler;
	}
}
