using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CF7 RID: 3319
	internal class XShopPurchaseView : DlgHandlerBase
	{
		// Token: 0x1700329E RID: 12958
		// (get) Token: 0x0600B98C RID: 47500 RVA: 0x0025B3CC File Offset: 0x002595CC
		protected override string FileName
		{
			get
			{
				return "Common/PurchaseFrame";
			}
		}

		// Token: 0x0600B98D RID: 47501 RVA: 0x0025B3E4 File Offset: 0x002595E4
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			this.mItemIcon = (base.PanelObject.transform.FindChild("Item/Icon").GetComponent("XUISprite") as IXUISprite);
			this.mItemName = (base.PanelObject.transform.FindChild("Item/Name").GetComponent("XUILabel") as IXUILabel);
			this.mItemOwnNum = (base.PanelObject.transform.FindChild("OP/own").GetComponent("XUILabel") as IXUILabel);
			this.mItemCanBuyNum = (base.PanelObject.transform.FindChild("OP/canbuy").GetComponent("XUILabel") as IXUILabel);
			this.mMinusTen = (base.PanelObject.transform.FindChild("OP/minus10").GetComponent("XUIButton") as IXUIButton);
			this.mMinusTen.ID = 10UL;
			this.mMinusOne = (base.PanelObject.transform.FindChild("OP/minus1").GetComponent("XUIButton") as IXUIButton);
			this.mMinusOne.ID = 1UL;
			this.mAddOne = (base.PanelObject.transform.FindChild("OP/add1").GetComponent("XUIButton") as IXUIButton);
			this.mAddOne.ID = 1UL;
			this.mAddTen = (base.PanelObject.transform.FindChild("OP/add10").GetComponent("XUIButton") as IXUIButton);
			this.mAddTen.ID = 10UL;
			this.mClose = (base.PanelObject.transform.FindChild("OP/close").GetComponent("XUIButton") as IXUIButton);
			this.mBlock = (base.PanelObject.transform.FindChild("block").GetComponent("XUIButton") as IXUIButton);
			this.mCurBuyNum = (base.PanelObject.transform.FindChild("buynum").GetComponent("XUILabel") as IXUILabel);
			this.mMoneyIcon = (base.PanelObject.transform.FindChild("moneysign").GetComponent("XUISprite") as IXUISprite);
			this.mMoneyNum = (base.PanelObject.transform.FindChild("moneynum").GetComponent("XUILabel") as IXUILabel);
			this.mDoBuy = (base.PanelObject.transform.FindChild("OP/OK").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x0600B98E RID: 47502 RVA: 0x0025B690 File Offset: 0x00259890
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.mMinusTen.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnMinusItem));
			this.mMinusOne.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnMinusItem));
			this.mAddTen.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAddItem));
			this.mAddOne.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAddItem));
			this.mDoBuy.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoPurchase));
			this.mClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosePurchaseView));
			this.mBlock.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosePurchaseView));
		}

		// Token: 0x0600B98F RID: 47503 RVA: 0x0025B74D File Offset: 0x0025994D
		protected override void OnShow()
		{
			base.OnShow();
			this._doc.PurchaseView = this;
		}

		// Token: 0x0600B990 RID: 47504 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600B991 RID: 47505 RVA: 0x0025B764 File Offset: 0x00259964
		public int GetMaxConstrainNum(int itemid, ulong moneynum, int price)
		{
			int num = (int)moneynum / price;
			int num2 = XShopPurchaseView.MAX_BUYNUM_ONE_TIME;
			ShopTable.RowData dataById = XNormalShopDocument.GetDataById((uint)this.mBuyGoods.item.uid);
			bool flag = dataById.DailyCountCondition > 0 || dataById.CountCondition > 0U || dataById.WeekCountCondition > 0;
			if (flag)
			{
				bool flag2 = dataById.CountCondition > 0U;
				if (flag2)
				{
					num2 = (int)(dataById.CountCondition - (uint)this.mBuyGoods.soldNum);
				}
				else
				{
					bool flag3 = dataById.DailyCountCondition > 0;
					if (flag3)
					{
						num2 = (int)dataById.DailyCountCondition - this.mBuyGoods.soldNum;
					}
					else
					{
						num2 = (int)((uint)dataById.WeekCountCondition - this.mBuyGoods.weeklyBuyCount);
					}
				}
				num2 = ((num2 >= 0) ? num2 : 0);
			}
			return num2;
		}

		// Token: 0x0600B992 RID: 47506 RVA: 0x0025B824 File Offset: 0x00259A24
		public int CalMaxCanBuyNum(int itemid, ulong moneynum, int price)
		{
			ShopTable.RowData dataById = XNormalShopDocument.GetDataById((uint)this.mBuyGoods.item.uid);
			bool flag = dataById.Benefit[0] == 2U;
			if (flag)
			{
				price = price * (int)dataById.Benefit[1] / 100;
			}
			int num = (int)moneynum / price;
			this.mMaxConstrainNum = this.GetMaxConstrainNum(itemid, moneynum, price);
			return (num < this.mMaxConstrainNum) ? num : this.mMaxConstrainNum;
		}

		// Token: 0x0600B993 RID: 47507 RVA: 0x0025B899 File Offset: 0x00259A99
		public void OnBuyItem(XNormalShopGoods goods)
		{
			base.SetVisible(true);
			this.mBuyGoods = goods;
			this.OnBuyItem(goods.item.itemID, goods.priceType, goods.priceValue);
		}

		// Token: 0x0600B994 RID: 47508 RVA: 0x0025B8CC File Offset: 0x00259ACC
		public int GetNeedMoney()
		{
			ShopTable.RowData dataById = XNormalShopDocument.GetDataById((uint)this.mBuyGoods.item.uid);
			bool flag = dataById.Benefit[0] == 2U;
			int result;
			if (flag)
			{
				result = this.mWantBuyNum * this.mPrice * (int)dataById.Benefit[1] / 100;
			}
			else
			{
				result = this.mWantBuyNum * this.mPrice;
			}
			return result;
		}

		// Token: 0x0600B995 RID: 47509 RVA: 0x0025B938 File Offset: 0x00259B38
		public void OnBuyItem(int itemid, int moneyid, int price)
		{
			this.mItemId = itemid;
			this.mWantBuyNum = 1;
			this.mMoneyType = moneyid;
			XSingleton<XItemDrawerMgr>.singleton.DrawItem(base.PanelObject.transform.FindChild("Item").gameObject, this.mBuyGoods.item);
			ulong itemCount = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(moneyid);
			ulong num = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(itemid);
			bool flag = num == 0UL;
			if (flag)
			{
				XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
				num = (ulong)((long)specificDocument.GetFashionCount(itemid));
			}
			this.mMaxCanBuyNum = this.CalMaxCanBuyNum(itemid, itemCount, price);
			this.mPrice = price;
			int maxConstrainNum = this.GetMaxConstrainNum(itemid, itemCount, price);
			this.mItemOwnNum.SetText(num.ToString());
			this.mCurBuyNum.SetText(this.mWantBuyNum.ToString());
			bool flag2 = maxConstrainNum == XShopPurchaseView.MAX_BUYNUM_ONE_TIME;
			if (flag2)
			{
				this.mItemCanBuyNum.SetVisible(false);
			}
			else
			{
				this.mItemCanBuyNum.SetVisible(true);
				this.mItemCanBuyNum.SetText(maxConstrainNum.ToString());
			}
			bool flag3 = !this._doc.IsMoneyOrItemEnough(this.mMoneyType, this.GetNeedMoney());
			if (flag3)
			{
				this.mMoneyNum.SetText("[fe0000]" + this.GetNeedMoney().ToString() + "[-]");
			}
			else
			{
				this.mMoneyNum.SetText(this.GetNeedMoney().ToString());
			}
			string itemSmallIcon = XBagDocument.GetItemSmallIcon(moneyid, 0U);
			this.mMoneyIcon.SetSprite(itemSmallIcon);
		}

		// Token: 0x0600B996 RID: 47510 RVA: 0x0025BAE0 File Offset: 0x00259CE0
		public bool OnAddItem(IXUIButton sp)
		{
			int num = this.mWantBuyNum;
			int num2 = (int)sp.ID;
			bool flag = this.mWantBuyNum + num2 >= this.mMaxCanBuyNum;
			if (flag)
			{
				this.mWantBuyNum = ((this.mMaxCanBuyNum == 0) ? 1 : this.mMaxCanBuyNum);
			}
			else
			{
				this.mWantBuyNum += num2;
			}
			bool flag2 = this.mWantBuyNum >= XShopPurchaseView.MAX_BUYNUM_ONE_TIME;
			if (flag2)
			{
				this.mWantBuyNum = ((XShopPurchaseView.MAX_BUYNUM_ONE_TIME == 0) ? 1 : XShopPurchaseView.MAX_BUYNUM_ONE_TIME);
			}
			this.mCurBuyNum.SetText(this.mWantBuyNum.ToString());
			bool flag3 = !this._doc.IsMoneyOrItemEnough(this.mMoneyType, this.GetNeedMoney());
			if (flag3)
			{
				this.mMoneyNum.SetText("[fe0000]" + this.GetNeedMoney().ToString() + "[-]");
			}
			else
			{
				this.mMoneyNum.SetText(this.GetNeedMoney().ToString());
			}
			bool flag4 = num == this.mWantBuyNum;
			if (flag4)
			{
				bool flag5 = this.mWantBuyNum == this.mMaxConstrainNum;
				if (flag5)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_BUY_LIMIT"), "fece00");
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_REINFORCE_LACKMONEY"), "fece00");
				}
			}
			return true;
		}

		// Token: 0x0600B997 RID: 47511 RVA: 0x0025BC44 File Offset: 0x00259E44
		public bool OnMinusItem(IXUIButton sp)
		{
			int num = (int)sp.ID;
			bool flag = this.mWantBuyNum - num <= 1;
			if (flag)
			{
				this.mWantBuyNum = 1;
			}
			else
			{
				this.mWantBuyNum -= num;
			}
			this.mCurBuyNum.SetText(this.mWantBuyNum.ToString());
			bool flag2 = !this._doc.IsMoneyOrItemEnough(this.mMoneyType, this.GetNeedMoney());
			if (flag2)
			{
				this.mMoneyNum.SetText("[fe0000]" + this.GetNeedMoney().ToString() + "[-]");
			}
			else
			{
				this.mMoneyNum.SetText(this.GetNeedMoney().ToString());
			}
			return true;
		}

		// Token: 0x0600B998 RID: 47512 RVA: 0x0025BD04 File Offset: 0x00259F04
		public bool DoPurchase(IXUIButton sp)
		{
			bool flag = this._doc.IsExchangeMoney(this.mMoneyType) && !this._doc.IsMoneyOrItemEnough(this.mMoneyType, this.GetNeedMoney());
			bool result;
			if (flag)
			{
				this._doc.ProcessItemOrMoneyNotEnough(this.mMoneyType);
				base.SetVisible(false);
				result = false;
			}
			else
			{
				bool flag2 = this.mWantBuyNum == 0;
				if (flag2)
				{
					base.SetVisible(false);
					result = false;
				}
				else
				{
					this._doc.DoBuyItem(this.mBuyGoods, (uint)this.mWantBuyNum);
					base.SetVisible(false);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600B999 RID: 47513 RVA: 0x0025BDA4 File Offset: 0x00259FA4
		public bool OnClosePurchaseView(IXUIButton sp)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x04004A2F RID: 18991
		public IXUISprite mItemIcon;

		// Token: 0x04004A30 RID: 18992
		public IXUILabel mItemName;

		// Token: 0x04004A31 RID: 18993
		public IXUILabel mItemOwnNum;

		// Token: 0x04004A32 RID: 18994
		public IXUILabel mItemCanBuyNum;

		// Token: 0x04004A33 RID: 18995
		public IXUIButton mMinusTen;

		// Token: 0x04004A34 RID: 18996
		public IXUIButton mMinusOne;

		// Token: 0x04004A35 RID: 18997
		public IXUIButton mAddOne;

		// Token: 0x04004A36 RID: 18998
		public IXUIButton mAddTen;

		// Token: 0x04004A37 RID: 18999
		public IXUIButton mClose;

		// Token: 0x04004A38 RID: 19000
		public IXUIButton mBlock;

		// Token: 0x04004A39 RID: 19001
		public IXUILabel mCurBuyNum;

		// Token: 0x04004A3A RID: 19002
		public IXUISprite mMoneyIcon;

		// Token: 0x04004A3B RID: 19003
		public IXUILabel mMoneyNum;

		// Token: 0x04004A3C RID: 19004
		public IXUIButton mDoBuy;

		// Token: 0x04004A3D RID: 19005
		private XNormalShopDocument _doc = null;

		// Token: 0x04004A3E RID: 19006
		private int mItemId = 0;

		// Token: 0x04004A3F RID: 19007
		private int mMoneyType = 0;

		// Token: 0x04004A40 RID: 19008
		private int mWantBuyNum = 0;

		// Token: 0x04004A41 RID: 19009
		private int mMaxCanBuyNum = 0;

		// Token: 0x04004A42 RID: 19010
		private int mMaxConstrainNum = 0;

		// Token: 0x04004A43 RID: 19011
		private int mPrice = 0;

		// Token: 0x04004A44 RID: 19012
		private XNormalShopGoods mBuyGoods;

		// Token: 0x04004A45 RID: 19013
		private static readonly int MAX_BUYNUM_ONE_TIME = 9999;
	}
}
