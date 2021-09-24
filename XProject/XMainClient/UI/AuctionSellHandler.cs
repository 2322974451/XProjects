using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class AuctionSellHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/Auction/AuctionSellFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<AuctionDocument>(AuctionDocument.uuID);
			this.m_auctionSellGroup = new AuctionWrapContentGroup();
			this.m_auctionSellGroup.SetAuctionWrapContentTemp(base.PanelObject.transform.FindChild("SellList"), new WrapItemUpdateEventHandler(this.OnAuctionSellListUpdate));
			this.m_bagWindow = new XBagWindow(base.PanelObject.transform.FindChild("BagList").gameObject, new ItemUpdateHandler(this.OnBagItemUpdate), new GetItemHandler(this._Doc.GetItemList));
			this.m_bagWindow.Init();
			this.m_emptyInAuction = base.PanelObject.transform.FindChild("SellListEmpty");
			this.m_curSaleValue = (base.PanelObject.transform.FindChild("LeftCount/Value").GetComponent("XUILabel") as IXUILabel);
			this.m_tqSprite = (base.PanelObject.transform.FindChild("tq").GetComponent("XUISprite") as IXUISprite);
			this.m_tqLabel = (base.PanelObject.transform.FindChild("tq/t").GetComponent("XUILabel") as IXUILabel);
			this.m_tqBgSprite = (base.PanelObject.transform.FindChild("tq/p").GetComponent("XUISprite") as IXUISprite);
		}

		private void OnAuctionSellListUpdate(Transform t, int index)
		{
			bool flag = t == null;
			if (!flag)
			{
				Transform transform = t.FindChild("DetailTpl");
				IXUICheckBox ixuicheckBox = transform.GetComponent("XUICheckBox") as IXUICheckBox;
				bool flag2 = ixuicheckBox != null;
				if (flag2)
				{
					ixuicheckBox.bChecked = false;
				}
				List<AuctionSaleItem> auctionOnLineSaleList = this._Doc.AuctionOnLineSaleList;
				bool flag3 = index < 0 || index >= auctionOnLineSaleList.Count;
				if (flag3)
				{
					transform.gameObject.SetActive(false);
				}
				else
				{
					transform.gameObject.SetActive(true);
					Transform transform2 = transform.FindChild("ItemTpl");
					IXUILabelSymbol ixuilabelSymbol = transform.FindChild("Price").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
					Transform transform3 = transform.FindChild("Time");
					IXUISprite ixuisprite = transform2.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					IXUISprite ixuisprite2 = transform.GetComponent("XUISprite") as IXUISprite;
					AuctionSaleItem auctionSaleItem = auctionOnLineSaleList[index];
					transform3.gameObject.SetActive(auctionSaleItem.isOutTime);
					ixuilabelSymbol.InputText = XLabelSymbolHelper.FormatCostWithIconLast((int)auctionSaleItem.perprice, ItemEnum.DRAGON_COIN);
					XSingleton<XItemDrawerMgr>.singleton.DrawItem(transform2.gameObject, auctionSaleItem.itemData);
					ixuisprite.ID = (ulong)((long)index);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemSaleClicked));
					ixuisprite2.ID = (ulong)((long)index);
					ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemSaleCheckSelected));
				}
			}
		}

		public override void RegisterEvent()
		{
			this.m_tqBgSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMemberPrivilegeClicked));
		}

		private void OnMemberPrivilegeClicked(IXUISprite sprite)
		{
			DlgBase<XWelfareView, XWelfareBehaviour>.singleton.CheckActiveMemberPrivilege(MemberPrivilege.KingdomPrivilege_Court);
		}

		private void OnBagItemUpdate(Transform transform, int index)
		{
			IXUISprite ixuisprite = transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			bool flag = this.m_bagWindow.m_XItemList == null || index < 0 || index >= this.m_bagWindow.m_XItemList.Count;
			if (flag)
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(transform.gameObject, null);
			}
			else
			{
				XItem xitem = this.m_bagWindow.m_XItemList[index];
				ixuisprite.ID = (ulong)((long)index);
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(transform.gameObject, xitem);
				GameObject gameObject = transform.Find("Icon/Bind").gameObject;
				gameObject.SetActive(xitem.blocking > 0.0);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemClicked));
			}
		}

		private void OnItemSaleCheckSelected(IXUISprite checkBox)
		{
			int num = (int)checkBox.ID;
			bool flag = num < this._Doc.AuctionOnLineSaleList.Count;
			if (flag)
			{
				AuctionSaleItem auctionSaleItem = this._Doc.AuctionOnLineSaleList[num];
				this._Doc.RequestAuctionPriceRecommend(auctionSaleItem.uid, auctionSaleItem.itemData, auctionSaleItem.isOutTime ? AuctionBillStyle.OutTime : AuctionBillStyle.RePutAway);
			}
		}

		private void OnItemSaleClicked(IXUISprite sp)
		{
			int num = (int)sp.ID;
			bool flag = num < this._Doc.AuctionOnLineSaleList.Count;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowTooltipDialog(this._Doc.AuctionOnLineSaleList[num].itemData, null, sp, false, 0U);
			}
		}

		private void OnItemClicked(IXUISprite sp)
		{
			int num = (int)sp.ID;
			bool flag = num < this.m_bagWindow.m_XItemList.Count;
			if (flag)
			{
				bool flag2 = this.m_bagWindow.m_XItemList[num].blocking > 0.0;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("AUCTION_LOCK_TIME", new object[]
					{
						XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)this.m_bagWindow.m_XItemList[num].blocking, 4)
					}), "fece00");
				}
				else
				{
					this._Doc.RequestAuctionPriceRecommend(0UL, this.m_bagWindow.m_XItemList[num], AuctionBillStyle.PutAway);
				}
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.RequestAuctionMySale();
			this.RefreshData();
		}

		public override void RefreshData()
		{
			this.m_bagWindow.OnShow();
			this.RefreshSaleList();
		}

		private void RefreshSaleList()
		{
			bool flag = this.m_auctionSellGroup == null;
			if (!flag)
			{
				int count = this._Doc.AuctionOnLineSaleList.Count;
				this.m_auctionSellGroup.SetWrapContentSize(count);
				this.m_emptyInAuction.gameObject.SetActive(count == 0);
				XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
				uint num = specificDocument.GetCurrentVipPermissions().AuctionOnSaleMax;
				XWelfareDocument specificDocument2 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
				this.m_tqSprite.SetSprite(specificDocument2.GetMemberPrivilegeIcon(MemberPrivilege.KingdomPrivilege_Court));
				bool flag2 = specificDocument2.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Court);
				if (flag2)
				{
					num += (uint)specificDocument2.GetMemberPrivilegeConfig(MemberPrivilege.KingdomPrivilege_Court).AuctionCount;
					this.m_tqSprite.SetGrey(true);
					this.m_tqLabel.SetEnabled(true);
				}
				else
				{
					this.m_tqSprite.SetGrey(false);
					this.m_tqLabel.SetEnabled(false);
				}
				this.m_curSaleValue.SetText(string.Format("{0}/{1}", count, num));
			}
		}

		private AuctionDocument _Doc;

		private AuctionWrapContentGroup m_auctionSellGroup;

		private XBagWindow m_bagWindow;

		private Transform m_emptyInAuction;

		private IXUILabel m_curSaleValue;

		private IXUISprite m_tqSprite;

		private IXUILabel m_tqLabel;

		private IXUISprite m_tqBgSprite;
	}
}
