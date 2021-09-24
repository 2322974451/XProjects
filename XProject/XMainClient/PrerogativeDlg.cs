using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class PrerogativeDlg : DlgBase<PrerogativeDlg, PrerogativeDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/Welfare/PrerogativeFrame";
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Prerogative);
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		protected override void OnLoad()
		{
			this._Doc.View = null;
			base.OnLoad();
		}

		protected override void Init()
		{
			base.Init();
			DlgHandlerBase.EnsureCreate<PreSettingNodeHandler>(ref this._settingHandler, base.uiBehaviour._setting.gameObject, this, false);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._Doc = XDocuments.GetSpecificDocument<XPrerogativeDocument>(XPrerogativeDocument.uuID);
			this._Doc.View = this;
			base.uiBehaviour._ruleBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnHelpHandler));
			base.uiBehaviour._shopBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.SkipToShop));
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickClose));
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		private bool _OnHelpHandler(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Prerogative);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.SetupFadeIn();
		}

		private bool ClickClose(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

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

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.Refresh();
		}

		public void Refresh()
		{
			this.SetupSetting();
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<PreSettingNodeHandler>(ref this._settingHandler);
			base.OnUnload();
		}

		private void SetupSetting()
		{
			bool flag = this._settingHandler != null && this._settingHandler.IsVisible();
			if (flag)
			{
				this._settingHandler.RefreshData();
			}
		}

		private bool SkipToShop(IXUIButton btn)
		{
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_PrerogativeShop, 0UL);
			return true;
		}

		private XPrerogativeDocument _Doc = null;

		private PreSettingNodeHandler _settingHandler;
	}
}
