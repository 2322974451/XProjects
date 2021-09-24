using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class SpriteSystemDlg : TabDlgBase<SpriteSystemDlg>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteSystemDlg";
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		protected override bool bHorizontal
		{
			get
			{
				return false;
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_SpriteSystem);
			}
		}

		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			this.parent = base.uiBehaviour.transform.Find("Bg");
			this.windowParent = base.uiBehaviour.transform.Find("Bg/Windows");
			base.RegisterSubSysRedPointMgr(XSysDefine.XSys_SpriteSystem);
			base.Init();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_illustration = (base.uiBehaviour.transform.Find("Bg/Illustration").GetComponent("XUIButton") as IXUIButton);
			this.m_illustration.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnIllustrationClicked));
			IXUIButton ixuibutton = base.uiBehaviour.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpBtnClicked));
		}

		protected override void OnLoad()
		{
			base.OnLoad();
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<SpriteMainFrame>(ref this._SpriteMainFrame);
			DlgHandlerBase.EnsureUnload<SpriteLotteryHandler>(ref this._SpriteLotteryHandler);
			DlgHandlerBase.EnsureUnload<SpriteFightFrame>(ref this._SpriteFightFrame);
			DlgHandlerBase.EnsureUnload<SpriteResolveFrame>(ref this._SpriteResolveFrame);
			DlgHandlerBase.EnsureUnload<SpriteStarUpWindow>(ref this._StarUpWindow);
			DlgHandlerBase.EnsureUnload<XSpriteIllustrationHandler>(ref this._IllustrationHandler);
			DlgHandlerBase.EnsureUnload<XSpriteAwakeHandler>(ref this._AwakeWindow);
			DlgHandlerBase.EnsureUnload<SpriteShopHandler>(ref this._SpriteShopHandler);
			base.OnUnload();
		}

		public override void SetupHandlers(XSysDefine sys)
		{
			this._CurrSys = sys;
			this._doc.SortList();
			switch (sys)
			{
			case XSysDefine.XSys_SpriteSystem_Main:
				this._doc.CurrentTag = SpriteHandlerTag.Main;
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<SpriteMainFrame>(ref this._SpriteMainFrame, this.parent, true, this));
				return;
			case XSysDefine.XSys_SpriteSystem_Lottery:
				this._doc.CurrentTag = SpriteHandlerTag.Lottery;
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<SpriteLotteryHandler>(ref this._SpriteLotteryHandler, this.parent, true, this));
				return;
			case XSysDefine.XSys_SpriteSystem_Fight:
				this._doc.CurrentTag = SpriteHandlerTag.Fight;
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<SpriteFightFrame>(ref this._SpriteFightFrame, this.parent, true, this));
				return;
			case XSysDefine.XSys_SpriteSystem_Resolve:
				this._doc.CurrentTag = SpriteHandlerTag.Resolve;
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<SpriteResolveFrame>(ref this._SpriteResolveFrame, this.parent, true, this));
				return;
			case XSysDefine.XSys_SpriteSystem_Shop:
				this._doc.CurrentTag = SpriteHandlerTag.Shop;
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<SpriteShopHandler>(ref this._SpriteShopHandler, this.parent, true, this));
				return;
			}
			XSingleton<XDebug>.singleton.AddErrorLog("System has not finished:", sys.ToString(), null, null, null, null);
		}

		public void RefreshTopUI()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				XMainInterfaceDocument specificDocument = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
				specificDocument.OnTopUIRefreshed(this);
			}
		}

		public override int[] GetTitanBarItems()
		{
			OpenSystemTable.RowData sysData = XSingleton<XGameSysMgr>.singleton.GetSysData(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(this._CurrSys));
			bool flag = sysData == null;
			int[] result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = sysData.TitanItems;
			}
			return result;
		}

		public void OpenWindows(SpriteWindow type)
		{
			switch (type)
			{
			case SpriteWindow.StarUp:
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<SpriteStarUpWindow>(ref this._StarUpWindow, this.windowParent, true, this));
				break;
			case SpriteWindow.Awake:
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XSpriteAwakeHandler>(ref this._AwakeWindow, this.windowParent, true, this));
				break;
			case SpriteWindow.Illustration:
				base._AddActiveHandler(DlgHandlerBase.EnsureCreate<XSpriteIllustrationHandler>(ref this._IllustrationHandler, this.windowParent, true, this));
				break;
			}
		}

		private bool OnIllustrationClicked(IXUIButton btn)
		{
			this.OpenWindows(SpriteWindow.Illustration);
			this._IllustrationHandler.ShowSpriteAllIllustration();
			return true;
		}

		private bool OnHelpBtnClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_SpriteSystem);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_illustration.SetVisible(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_SpriteSystem_Lottery));
			this.CheckSpriteSummonRedpoint();
		}

		public void CheckSpriteSummonRedpoint()
		{
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("SpriteDrawCost").Split(XGlobalConfig.SequenceSeparator);
			string[] array2 = XSingleton<XGlobalConfig>.singleton.GetValue("SpriteGoldDrawCost").Split(XGlobalConfig.SequenceSeparator);
			bool flag = array.Length != 2 || array2.Length != 2;
			if (!flag)
			{
				XBagDocument specificDocument = XDocuments.GetSpecificDocument<XBagDocument>(XBagDocument.uuID);
				bool bState = specificDocument.GetItemCount(int.Parse(array[0])) > 0UL || specificDocument.GetItemCount(int.Parse(array2[0])) > 0UL;
				XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_SpriteSystem_Lottery, bState);
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_SpriteSystem_Lottery, true);
			}
		}

		private IXUIButton m_illustration;

		private Transform parent;

		public SpriteMainFrame _SpriteMainFrame;

		public SpriteLotteryHandler _SpriteLotteryHandler;

		public SpriteFightFrame _SpriteFightFrame;

		public SpriteResolveFrame _SpriteResolveFrame;

		public SpriteShopHandler _SpriteShopHandler;

		private Transform windowParent;

		public SpriteStarUpWindow _StarUpWindow;

		public XSpriteIllustrationHandler _IllustrationHandler;

		public XSpriteAwakeHandler _AwakeWindow;

		private XSpriteSystemDocument _doc;

		private XSysDefine _CurrSys;
	}
}
