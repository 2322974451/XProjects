using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C00 RID: 3072
	internal class GiftClaimDlg : DlgBase<GiftClaimDlg, GiftClaimBehaviour>
	{
		// Token: 0x170030CB RID: 12491
		// (get) Token: 0x0600AEAF RID: 44719 RVA: 0x0020E61C File Offset: 0x0020C81C
		public override bool isPopup
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030CC RID: 12492
		// (get) Token: 0x0600AEB0 RID: 44720 RVA: 0x0020E630 File Offset: 0x0020C830
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170030CD RID: 12493
		// (get) Token: 0x0600AEB1 RID: 44721 RVA: 0x0020E644 File Offset: 0x0020C844
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170030CE RID: 12494
		// (get) Token: 0x0600AEB2 RID: 44722 RVA: 0x0020E658 File Offset: 0x0020C858
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030CF RID: 12495
		// (get) Token: 0x0600AEB3 RID: 44723 RVA: 0x0020E66C File Offset: 0x0020C86C
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030D0 RID: 12496
		// (get) Token: 0x0600AEB4 RID: 44724 RVA: 0x0020E680 File Offset: 0x0020C880
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170030D1 RID: 12497
		// (get) Token: 0x0600AEB5 RID: 44725 RVA: 0x0020E694 File Offset: 0x0020C894
		public override string fileName
		{
			get
			{
				return "GameSystem/GiftClaimDlg";
			}
		}

		// Token: 0x170030D2 RID: 12498
		// (get) Token: 0x0600AEB6 RID: 44726 RVA: 0x0020E6AC File Offset: 0x0020C8AC
		public XGameMallDocument doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			}
		}

		// Token: 0x0600AEB7 RID: 44727 RVA: 0x0020E6C8 File Offset: 0x0020C8C8
		protected override void Init()
		{
			base.Init();
		}

		// Token: 0x0600AEB8 RID: 44728 RVA: 0x0020E6D4 File Offset: 0x0020C8D4
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

		// Token: 0x0600AEB9 RID: 44729 RVA: 0x0020E744 File Offset: 0x0020C944
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btnOpen.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOpenClick));
			base.uiBehaviour.m_btnThanks.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnThankClick));
		}

		// Token: 0x0600AEBA RID: 44730 RVA: 0x0020E794 File Offset: 0x0020C994
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

		// Token: 0x0600AEBB RID: 44731 RVA: 0x0020E7D4 File Offset: 0x0020C9D4
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

		// Token: 0x0600AEBC RID: 44732 RVA: 0x0020E91C File Offset: 0x0020CB1C
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

		// Token: 0x0600AEBD RID: 44733 RVA: 0x0020E95C File Offset: 0x0020CB5C
		private bool OnOpenClick(IXUIButton btn)
		{
			this.state = GiftClaimDlg.State.Open;
			this.RefreshUI();
			return true;
		}

		// Token: 0x0600AEBE RID: 44734 RVA: 0x0020E980 File Offset: 0x0020CB80
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

		// Token: 0x04004267 RID: 16999
		public GiftClaimDlg.State state = GiftClaimDlg.State.Recv;

		// Token: 0x04004268 RID: 17000
		private XFx fx;

		// Token: 0x04004269 RID: 17001
		private List<GiftIbItem> mGiftList;

		// Token: 0x020019A3 RID: 6563
		public enum State
		{
			// Token: 0x04007F56 RID: 32598
			Recv,
			// Token: 0x04007F57 RID: 32599
			Open
		}
	}
}
