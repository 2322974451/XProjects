using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XShopPurchaseView : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Common/PurchaseFrame";
			}
		}

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

		protected override void OnShow()
		{
			base.OnShow();
			this._doc.PurchaseView = this;
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

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

		public void OnBuyItem(XNormalShopGoods goods)
		{
			base.SetVisible(true);
			this.mBuyGoods = goods;
			this.OnBuyItem(goods.item.itemID, goods.priceType, goods.priceValue);
		}

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

		public bool OnClosePurchaseView(IXUIButton sp)
		{
			base.SetVisible(false);
			return true;
		}

		public IXUISprite mItemIcon;

		public IXUILabel mItemName;

		public IXUILabel mItemOwnNum;

		public IXUILabel mItemCanBuyNum;

		public IXUIButton mMinusTen;

		public IXUIButton mMinusOne;

		public IXUIButton mAddOne;

		public IXUIButton mAddTen;

		public IXUIButton mClose;

		public IXUIButton mBlock;

		public IXUILabel mCurBuyNum;

		public IXUISprite mMoneyIcon;

		public IXUILabel mMoneyNum;

		public IXUIButton mDoBuy;

		private XNormalShopDocument _doc = null;

		private int mItemId = 0;

		private int mMoneyType = 0;

		private int mWantBuyNum = 0;

		private int mMaxCanBuyNum = 0;

		private int mMaxConstrainNum = 0;

		private int mPrice = 0;

		private XNormalShopGoods mBuyGoods;

		private static readonly int MAX_BUYNUM_ONE_TIME = 9999;
	}
}
