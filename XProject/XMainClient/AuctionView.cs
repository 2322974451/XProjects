using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B92 RID: 2962
	internal class AuctionView : DlgBase<AuctionView, AuctionBehaviour>
	{
		// Token: 0x1700302E RID: 12334
		// (get) Token: 0x0600A9B3 RID: 43443 RVA: 0x001E421C File Offset: 0x001E241C
		public override string fileName
		{
			get
			{
				return "GameSystem/Auction/AuctionDlg";
			}
		}

		// Token: 0x1700302F RID: 12335
		// (get) Token: 0x0600A9B4 RID: 43444 RVA: 0x001E4234 File Offset: 0x001E2434
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003030 RID: 12336
		// (get) Token: 0x0600A9B5 RID: 43445 RVA: 0x001E4248 File Offset: 0x001E2448
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003031 RID: 12337
		// (get) Token: 0x0600A9B6 RID: 43446 RVA: 0x001E425C File Offset: 0x001E245C
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003032 RID: 12338
		// (get) Token: 0x0600A9B7 RID: 43447 RVA: 0x001E4270 File Offset: 0x001E2470
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003033 RID: 12339
		// (get) Token: 0x0600A9B8 RID: 43448 RVA: 0x001E4284 File Offset: 0x001E2484
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600A9B9 RID: 43449 RVA: 0x001E4297 File Offset: 0x001E2497
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<AuctionDocument>(AuctionDocument.uuID);
			this.RegisterHandler<AuctionSellHandler>(AuctionSys.Sell);
			this.RegisterHandler<AuctionBuyHandler>(AuctionSys.Buy);
			this.RegisterHandler<AuctionHouseHandler>(AuctionSys.GuildAuc);
		}

		// Token: 0x0600A9BA RID: 43450 RVA: 0x001E42CC File Offset: 0x001E24CC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_BuyFrameCheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnBuyFrameCheckBoxClicked));
			base.uiBehaviour.m_SellFrameCheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSellFrameCheckBoxClicked));
			base.uiBehaviour.m_GuildAucFrameCheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnGuildAucFrameCheckBoxClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		// Token: 0x0600A9BB RID: 43451 RVA: 0x001E4374 File Offset: 0x001E2574
		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Auction);
			return true;
		}

		// Token: 0x0600A9BC RID: 43452 RVA: 0x001E4394 File Offset: 0x001E2594
		public void RefreshData()
		{
			DlgHandlerBase dlgHandlerBase;
			bool flag = this.m_handlers.TryGetValue(this.m_curAuctionSys, out dlgHandlerBase) && dlgHandlerBase.IsVisible();
			if (flag)
			{
				dlgHandlerBase.RefreshData();
			}
		}

		// Token: 0x0600A9BD RID: 43453 RVA: 0x001E43D0 File Offset: 0x001E25D0
		protected override void OnShow()
		{
			base.OnShow();
			this.m_uiBehaviour.m_BuyFrameCheckBox.bChecked = true;
			this._Doc.SetSendAuctionState(false);
			this.SetHandlerVisible(AuctionSys.Buy, true);
			this.RefreshData();
			base.uiBehaviour.m_GuildAucRedPoint.SetActive(XSingleton<XGameSysMgr>.singleton.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Auction));
		}

		// Token: 0x0600A9BE RID: 43454 RVA: 0x001E4431 File Offset: 0x001E2631
		protected override void OnHide()
		{
			this.SetHandlerVisible(AuctionSys.Sell, false);
			this.SetHandlerVisible(AuctionSys.Buy, false);
			this.SetHandlerVisible(AuctionSys.GuildAuc, false);
			base.OnHide();
		}

		// Token: 0x0600A9BF RID: 43455 RVA: 0x001E4456 File Offset: 0x001E2656
		protected override void OnUnload()
		{
			this.RemoveHandler(AuctionSys.Sell);
			this.RemoveHandler(AuctionSys.Buy);
			this.RemoveHandler(AuctionSys.GuildAuc);
			base.OnUnload();
		}

		// Token: 0x0600A9C0 RID: 43456 RVA: 0x001E4478 File Offset: 0x001E2678
		private bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600A9C1 RID: 43457 RVA: 0x001E4494 File Offset: 0x001E2694
		private bool OnBuyFrameCheckBoxClicked(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.OnTabChanged(AuctionSys.Buy);
				result = true;
			}
			return result;
		}

		// Token: 0x0600A9C2 RID: 43458 RVA: 0x001E44C0 File Offset: 0x001E26C0
		private bool OnSellFrameCheckBoxClicked(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.OnTabChanged(AuctionSys.Sell);
				result = true;
			}
			return result;
		}

		// Token: 0x0600A9C3 RID: 43459 RVA: 0x001E44EC File Offset: 0x001E26EC
		private bool OnGuildAucFrameCheckBoxClicked(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.OnTabChanged(AuctionSys.GuildAuc);
				result = true;
			}
			return result;
		}

		// Token: 0x0600A9C4 RID: 43460 RVA: 0x001E4518 File Offset: 0x001E2718
		private void OnTabChanged(AuctionSys define)
		{
			bool flag = define == this.m_curAuctionSys;
			if (!flag)
			{
				this.SetHandlerVisible(this.m_curAuctionSys, false);
				this.SetHandlerVisible(define, true);
			}
		}

		// Token: 0x0600A9C5 RID: 43461 RVA: 0x001E454C File Offset: 0x001E274C
		private void SetHandlerVisible(AuctionSys define, bool isVisble)
		{
			DlgHandlerBase dlgHandlerBase;
			bool flag = this.m_handlers.TryGetValue(define, out dlgHandlerBase);
			if (flag)
			{
				dlgHandlerBase.SetVisible(isVisble);
				if (isVisble)
				{
					this.m_curAuctionSys = define;
				}
			}
		}

		// Token: 0x0600A9C6 RID: 43462 RVA: 0x001E4584 File Offset: 0x001E2784
		private void RegisterHandler<T>(AuctionSys define) where T : DlgHandlerBase, new()
		{
			bool flag = !this.m_handlers.ContainsKey(define);
			if (flag)
			{
				T t = default(T);
				t = DlgHandlerBase.EnsureCreate<T>(ref t, base.uiBehaviour.m_framesTransform, false, this);
				this.m_handlers.Add(define, t);
			}
		}

		// Token: 0x0600A9C7 RID: 43463 RVA: 0x001E45D8 File Offset: 0x001E27D8
		private void RemoveHandler(AuctionSys define)
		{
			DlgHandlerBase dlgHandlerBase;
			bool flag = this.m_handlers.TryGetValue(define, out dlgHandlerBase);
			if (flag)
			{
				DlgHandlerBase.EnsureUnload<DlgHandlerBase>(ref dlgHandlerBase);
				this.m_handlers.Remove(define);
			}
		}

		// Token: 0x0600A9C8 RID: 43464 RVA: 0x001E460F File Offset: 0x001E280F
		public void SetGuildAuctionRedPointState(bool state)
		{
			base.uiBehaviour.m_GuildAucRedPoint.SetActive(state);
		}

		// Token: 0x04003ED5 RID: 16085
		private AuctionDocument _Doc;

		// Token: 0x04003ED6 RID: 16086
		private Dictionary<AuctionSys, DlgHandlerBase> m_handlers = new Dictionary<AuctionSys, DlgHandlerBase>();

		// Token: 0x04003ED7 RID: 16087
		private AuctionSys m_curAuctionSys;
	}
}
