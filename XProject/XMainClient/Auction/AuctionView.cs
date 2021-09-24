using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AuctionView : DlgBase<AuctionView, AuctionBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/Auction/AuctionDlg";
			}
		}

		public override int group
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

		public override bool hideMainMenu
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
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<AuctionDocument>(AuctionDocument.uuID);
			this.RegisterHandler<AuctionSellHandler>(AuctionSys.Sell);
			this.RegisterHandler<AuctionBuyHandler>(AuctionSys.Buy);
			this.RegisterHandler<AuctionHouseHandler>(AuctionSys.GuildAuc);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_BuyFrameCheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnBuyFrameCheckBoxClicked));
			base.uiBehaviour.m_SellFrameCheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSellFrameCheckBoxClicked));
			base.uiBehaviour.m_GuildAucFrameCheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnGuildAucFrameCheckBoxClicked));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Auction);
			return true;
		}

		public void RefreshData()
		{
			DlgHandlerBase dlgHandlerBase;
			bool flag = this.m_handlers.TryGetValue(this.m_curAuctionSys, out dlgHandlerBase) && dlgHandlerBase.IsVisible();
			if (flag)
			{
				dlgHandlerBase.RefreshData();
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_uiBehaviour.m_BuyFrameCheckBox.bChecked = true;
			this._Doc.SetSendAuctionState(false);
			this.SetHandlerVisible(AuctionSys.Buy, true);
			this.RefreshData();
			base.uiBehaviour.m_GuildAucRedPoint.SetActive(XSingleton<XGameSysMgr>.singleton.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Auction));
		}

		protected override void OnHide()
		{
			this.SetHandlerVisible(AuctionSys.Sell, false);
			this.SetHandlerVisible(AuctionSys.Buy, false);
			this.SetHandlerVisible(AuctionSys.GuildAuc, false);
			base.OnHide();
		}

		protected override void OnUnload()
		{
			this.RemoveHandler(AuctionSys.Sell);
			this.RemoveHandler(AuctionSys.Buy);
			this.RemoveHandler(AuctionSys.GuildAuc);
			base.OnUnload();
		}

		private bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

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

		private void OnTabChanged(AuctionSys define)
		{
			bool flag = define == this.m_curAuctionSys;
			if (!flag)
			{
				this.SetHandlerVisible(this.m_curAuctionSys, false);
				this.SetHandlerVisible(define, true);
			}
		}

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

		public void SetGuildAuctionRedPointState(bool state)
		{
			base.uiBehaviour.m_GuildAucRedPoint.SetActive(state);
		}

		private AuctionDocument _Doc;

		private Dictionary<AuctionSys, DlgHandlerBase> m_handlers = new Dictionary<AuctionSys, DlgHandlerBase>();

		private AuctionSys m_curAuctionSys;
	}
}
