using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GiftClaimDlg : DlgBase<GiftClaimDlg, GiftClaimBehaviour>
	{

		public override bool isPopup
		{
			get
			{
				return true;
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
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

		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/GiftClaimDlg";
			}
		}

		public XGameMallDocument doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			}
		}

		protected override void Init()
		{
			base.Init();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshUI();
			bool flag = this.fx == null;
			if (flag)
			{
				this.fx = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_GiftClaimDlg_Clip01", null, true);
				this.fx.Play(base.uiBehaviour.m_objTpl.transform, Vector3.zero, Vector3.one, 1f, true, false);
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btnOpen.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOpenClick));
			base.uiBehaviour.m_btnThanks.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnThankClick));
		}

		protected override void OnUnload()
		{
			bool flag = this.fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.fx, true);
				this.fx = null;
			}
			base.OnUnload();
		}

		private void RefreshUI()
		{
			base.uiBehaviour.m_transOpen.gameObject.SetActive(this.state == GiftClaimDlg.State.Open);
			base.uiBehaviour.m_transRcv.gameObject.SetActive(this.state == GiftClaimDlg.State.Recv);
			bool flag = this.state == GiftClaimDlg.State.Recv;
			if (flag)
			{
				bool flag2 = this.mGiftList != null && this.mGiftList.Count > 0;
				if (flag2)
				{
					GiftIbItem giftIbItem = this.mGiftList[0];
					base.uiBehaviour.m_lblName.SetText(giftIbItem.name);
				}
			}
			else
			{
				bool flag3 = this.state == GiftClaimDlg.State.Open;
				if (flag3)
				{
					bool flag4 = this.mGiftList != null && this.mGiftList.Count > 0;
					if (flag4)
					{
						GiftIbItem giftIbItem2 = this.mGiftList[0];
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(base.uiBehaviour.m_objTpl, (int)giftIbItem2.item.itemID, (int)giftIbItem2.item.itemCount, false);
						base.uiBehaviour.m_lblDetail.SetText(giftIbItem2.text);
						base.uiBehaviour.m_lblTitle.SetText(giftIbItem2.name);
					}
				}
			}
		}

		public void HanderGift(List<GiftIbItem> gift)
		{
			this.mGiftList = gift;
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				this.state = GiftClaimDlg.State.Recv;
				this.SetVisible(true, true);
			}
		}

		private bool OnOpenClick(IXUIButton btn)
		{
			this.state = GiftClaimDlg.State.Open;
			this.RefreshUI();
			return true;
		}

		private bool OnThankClick(IXUIButton btn)
		{
			bool flag = this.mGiftList == null;
			if (flag)
			{
				this.SetVisible(false, true);
			}
			else
			{
				bool flag2 = this.mGiftList.Count > 0;
				if (flag2)
				{
					GiftIbItem giftIbItem = this.mGiftList[0];
					RpcC2M_GiftIbReqGoods rpcC2M_GiftIbReqGoods = new RpcC2M_GiftIbReqGoods();
					rpcC2M_GiftIbReqGoods.oArg.orderid = giftIbItem.orderid;
					XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GiftIbReqGoods);
					this.mGiftList.RemoveAt(0);
				}
				bool flag3 = this.mGiftList.Count > 0;
				if (flag3)
				{
					this.state = GiftClaimDlg.State.Recv;
					this.RefreshUI();
				}
				else
				{
					this.SetVisible(false, true);
				}
			}
			return true;
		}

		public GiftClaimDlg.State state = GiftClaimDlg.State.Recv;

		private XFx fx;

		private List<GiftIbItem> mGiftList;

		public enum State
		{

			Recv,

			Open
		}
	}
}
