using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class SelectNumFrameDlg : DlgBase<SelectNumFrameDlg, SelectNumFrameBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/Auction/AuctionBillFrame2";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XRecycleItemDocument>(XRecycleItemDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closespr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickClosed));
			base.uiBehaviour.m_sureBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickSureBtn));
			base.uiBehaviour.m_SinglePriceOperate.RegisterOperateChange(new AuctionNumberOperate.NumberOperateCallBack(this.OnNumOperateChange));
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		public void Show(ulong uid)
		{
			this.m_uid = uid;
			this.SetVisible(true, true);
		}

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

		private void OnNumOperateChange()
		{
		}

		private void OnClickClosed(IXUISprite spr)
		{
			this.SetVisible(false, true);
		}

		private bool OnClickSureBtn(IXUIButton btn)
		{
			this.SetVisible(false, true);
			this.m_doc._ToggleItemSelect(true, this.m_uid, (ulong)((long)base.uiBehaviour.m_SinglePriceOperate.Cur), true);
			return true;
		}

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

		private XRecycleItemDocument m_doc;

		private ulong m_uid;
	}
}
