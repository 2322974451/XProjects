using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200185D RID: 6237
	internal class SpriteSystemDlg : TabDlgBase<SpriteSystemDlg>
	{
		// Token: 0x1700398A RID: 14730
		// (get) Token: 0x060103D2 RID: 66514 RVA: 0x003EC6D4 File Offset: 0x003EA8D4
		public override string fileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteSystemDlg";
			}
		}

		// Token: 0x1700398B RID: 14731
		// (get) Token: 0x060103D3 RID: 66515 RVA: 0x003EC6EC File Offset: 0x003EA8EC
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700398C RID: 14732
		// (get) Token: 0x060103D4 RID: 66516 RVA: 0x003EC700 File Offset: 0x003EA900
		protected override bool bHorizontal
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700398D RID: 14733
		// (get) Token: 0x060103D5 RID: 66517 RVA: 0x003EC714 File Offset: 0x003EA914
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_SpriteSystem);
			}
		}

		// Token: 0x060103D6 RID: 66518 RVA: 0x003EC730 File Offset: 0x003EA930
		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			this.parent = base.uiBehaviour.transform.Find("Bg");
			this.windowParent = base.uiBehaviour.transform.Find("Bg/Windows");
			base.RegisterSubSysRedPointMgr(XSysDefine.XSys_SpriteSystem);
			base.Init();
		}

		// Token: 0x060103D7 RID: 66519 RVA: 0x003EC798 File Offset: 0x003EA998
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_illustration = (base.uiBehaviour.transform.Find("Bg/Illustration").GetComponent("XUIButton") as IXUIButton);
			this.m_illustration.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnIllustrationClicked));
			IXUIButton ixuibutton = base.uiBehaviour.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpBtnClicked));
		}

		// Token: 0x060103D8 RID: 66520 RVA: 0x003EC827 File Offset: 0x003EAA27
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x060103D9 RID: 66521 RVA: 0x003EC834 File Offset: 0x003EAA34
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

		// Token: 0x060103DA RID: 66522 RVA: 0x003EC8AC File Offset: 0x003EAAAC
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

		// Token: 0x060103DB RID: 66523 RVA: 0x003EC9F4 File Offset: 0x003EABF4
		public void RefreshTopUI()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				XMainInterfaceDocument specificDocument = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
				specificDocument.OnTopUIRefreshed(this);
			}
		}

		// Token: 0x060103DC RID: 66524 RVA: 0x003ECA24 File Offset: 0x003EAC24
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

		// Token: 0x060103DD RID: 66525 RVA: 0x003ECA60 File Offset: 0x003EAC60
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

		// Token: 0x060103DE RID: 66526 RVA: 0x003ECADC File Offset: 0x003EACDC
		private bool OnIllustrationClicked(IXUIButton btn)
		{
			this.OpenWindows(SpriteWindow.Illustration);
			this._IllustrationHandler.ShowSpriteAllIllustration();
			return true;
		}

		// Token: 0x060103DF RID: 66527 RVA: 0x003ECB04 File Offset: 0x003EAD04
		private bool OnHelpBtnClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_SpriteSystem);
			return true;
		}

		// Token: 0x060103E0 RID: 66528 RVA: 0x003ECB27 File Offset: 0x003EAD27
		protected override void OnShow()
		{
			base.OnShow();
			this.m_illustration.SetVisible(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_SpriteSystem_Lottery));
			this.CheckSpriteSummonRedpoint();
		}

		// Token: 0x060103E1 RID: 66529 RVA: 0x003ECB54 File Offset: 0x003EAD54
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

		// Token: 0x040074A5 RID: 29861
		private IXUIButton m_illustration;

		// Token: 0x040074A6 RID: 29862
		private Transform parent;

		// Token: 0x040074A7 RID: 29863
		public SpriteMainFrame _SpriteMainFrame;

		// Token: 0x040074A8 RID: 29864
		public SpriteLotteryHandler _SpriteLotteryHandler;

		// Token: 0x040074A9 RID: 29865
		public SpriteFightFrame _SpriteFightFrame;

		// Token: 0x040074AA RID: 29866
		public SpriteResolveFrame _SpriteResolveFrame;

		// Token: 0x040074AB RID: 29867
		public SpriteShopHandler _SpriteShopHandler;

		// Token: 0x040074AC RID: 29868
		private Transform windowParent;

		// Token: 0x040074AD RID: 29869
		public SpriteStarUpWindow _StarUpWindow;

		// Token: 0x040074AE RID: 29870
		public XSpriteIllustrationHandler _IllustrationHandler;

		// Token: 0x040074AF RID: 29871
		public XSpriteAwakeHandler _AwakeWindow;

		// Token: 0x040074B0 RID: 29872
		private XSpriteSystemDocument _doc;

		// Token: 0x040074B1 RID: 29873
		private XSysDefine _CurrSys;
	}
}
