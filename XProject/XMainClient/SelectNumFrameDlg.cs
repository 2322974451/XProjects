using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C70 RID: 3184
	internal class SelectNumFrameDlg : DlgBase<SelectNumFrameDlg, SelectNumFrameBehaviour>
	{
		// Token: 0x170031E6 RID: 12774
		// (get) Token: 0x0600B41A RID: 46106 RVA: 0x00232000 File Offset: 0x00230200
		public override string fileName
		{
			get
			{
				return "GameSystem/Auction/AuctionBillFrame2";
			}
		}

		// Token: 0x170031E7 RID: 12775
		// (get) Token: 0x0600B41B RID: 46107 RVA: 0x00232018 File Offset: 0x00230218
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B41C RID: 46108 RVA: 0x0023202B File Offset: 0x0023022B
		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XRecycleItemDocument>(XRecycleItemDocument.uuID);
		}

		// Token: 0x0600B41D RID: 46109 RVA: 0x00232048 File Offset: 0x00230248
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closespr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickClosed));
			base.uiBehaviour.m_sureBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickSureBtn));
			base.uiBehaviour.m_SinglePriceOperate.RegisterOperateChange(new AuctionNumberOperate.NumberOperateCallBack(this.OnNumOperateChange));
		}

		// Token: 0x0600B41E RID: 46110 RVA: 0x002320B4 File Offset: 0x002302B4
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B41F RID: 46111 RVA: 0x002320BE File Offset: 0x002302BE
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x0600B420 RID: 46112 RVA: 0x002320CF File Offset: 0x002302CF
		public void Show(ulong uid)
		{
			this.m_uid = uid;
			this.SetVisible(true, true);
		}

		// Token: 0x0600B421 RID: 46113 RVA: 0x002320E4 File Offset: 0x002302E4
		private void FillContent()
		{
			int num = 0;
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_uid);
			bool flag = itemByUID != null;
			if (flag)
			{
				num = itemByUID.itemCount - this.m_doc.GetSelectUidCount(this.m_uid);
			}
			XSingleton<XItemDrawerMgr>.singleton.DrawItem(base.uiBehaviour.m_itemGo, itemByUID);
			IXUISprite ixuisprite = base.uiBehaviour.m_itemGo.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = this.m_uid;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickTips));
			base.uiBehaviour.m_SinglePriceOperate.Set(num, 1, num, 1, true, true);
		}

		// Token: 0x0600B422 RID: 46114 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void OnNumOperateChange()
		{
		}

		// Token: 0x0600B423 RID: 46115 RVA: 0x0023219E File Offset: 0x0023039E
		private void OnClickClosed(IXUISprite spr)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x0600B424 RID: 46116 RVA: 0x002321AC File Offset: 0x002303AC
		private bool OnClickSureBtn(IXUIButton btn)
		{
			this.SetVisible(false, true);
			this.m_doc._ToggleItemSelect(true, this.m_uid, (ulong)((long)base.uiBehaviour.m_SinglePriceOperate.Cur), true);
			return true;
		}

		// Token: 0x0600B425 RID: 46117 RVA: 0x002321F0 File Offset: 0x002303F0
		private void OnClickTips(IXUISprite spr)
		{
			bool flag = spr.ID == 0UL;
			if (!flag)
			{
				XItem xitem = XBagDocument.BagDoc.GetBagItemByUID(spr.ID);
				bool flag2 = xitem == null;
				if (flag2)
				{
					xitem = XBagDocument.MakeXItem((int)spr.ID, false);
				}
				XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(xitem, spr, false, 0U);
			}
		}

		// Token: 0x040045D4 RID: 17876
		private XRecycleItemDocument m_doc;

		// Token: 0x040045D5 RID: 17877
		private ulong m_uid;
	}
}
