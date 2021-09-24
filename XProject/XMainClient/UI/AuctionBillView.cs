using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class AuctionBillView : DlgBase<AuctionBillView, AuctionBillBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/Auction/AuctionBillFrame";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public void Set(XItem item, AuctionBillStyle style = AuctionBillStyle.PutAway, ulong uid = 0UL)
		{
			this.m_aucuid = uid;
			this.m_curBillStyle = style;
			this.m_curItem = item;
			bool flag = this.m_curItem != null;
			if (flag)
			{
				this.SetVisibleWithAnimation(true, null);
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_billStyles = new Dictionary<AuctionBillStyle, string[]>();
			this.m_billStyles[AuctionBillStyle.PutAway] = new string[2];
			this.m_billStyles[AuctionBillStyle.PutAway][0] = XStringDefineProxy.GetString("AUCTION_PUTAWAY");
			this.m_billStyles[AuctionBillStyle.PutAway][1] = string.Empty;
			this.m_billStyles[AuctionBillStyle.RePutAway] = new string[2];
			this.m_billStyles[AuctionBillStyle.RePutAway][0] = XStringDefineProxy.GetString("AUCTION_RPUTAWAY");
			this.m_billStyles[AuctionBillStyle.RePutAway][1] = XStringDefineProxy.GetString("ACUTION_SOLDOUT");
			this.m_billStyles[AuctionBillStyle.OutTime] = new string[2];
			this.m_billStyles[AuctionBillStyle.OutTime][0] = XStringDefineProxy.GetString("AUCTION_RPUTAWAY");
			this.m_billStyles[AuctionBillStyle.OutTime][1] = XStringDefineProxy.GetString("AUCTION_PUTDOWN");
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_LeftButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickLeftHandler));
			base.uiBehaviour.m_RightButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickRightHandler));
			base.uiBehaviour.m_SinglePriceOperate.RegisterOperateChange(new AuctionNumberOperate.NumberOperateCallBack(this.OnTotalPriceOperateChange));
			base.uiBehaviour.m_CountOperate.RegisterOperateChange(new AuctionNumberOperate.NumberOperateCallBack(this.OnTotalPriceOperateChange));
			base.uiBehaviour.m_CloseButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickCloseHandler));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.SetDetailInfo();
		}

		private void SetDetailInfo()
		{
			base.uiBehaviour.m_billTitleTxt.SetText(XStringDefineProxy.GetString((this.m_curBillStyle == AuctionBillStyle.OutTime) ? "AUCTION_TITLE_OUTTIME" : "AUCTION_TITLE_PUTAWAY"));
			AuctionDocument specificDocument = XDocuments.GetSpecificDocument<AuctionDocument>(AuctionDocument.uuID);
			base.uiBehaviour.SetButtonPosition(this.m_billStyles[this.m_curBillStyle]);
			ItemList.RowData itemConf = XBagDocument.GetItemConf(this.m_curItem.itemID);
			float discount = AuctionDocument.GetDiscount((uint)itemConf.AuctionGroup);
			float num = this.m_curItem.Treasure ? float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("AuctTreasureTJPriceRate")) : 1f;
			this.m_referPrice = Mathf.FloorToInt(itemConf.AuctPriceRecommend * discount * num);
			uint referPrice;
			bool flag = !specificDocument.TryGetAuctionBriefReferPrice((uint)this.m_curItem.itemID, out referPrice) || referPrice == 0U;
			if (flag)
			{
				referPrice = (uint)this.m_referPrice;
			}
			float num2 = itemConf.AuctionRange[1];
			float num3 = itemConf.AuctionRange[0];
			int step = Mathf.CeilToInt((float)this.m_referPrice * float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("AuctionOperStep")));
			base.uiBehaviour.m_RecentPrice.SetText(referPrice.ToString());
			base.uiBehaviour.m_SinglePriceOperate.Set(Mathf.FloorToInt(num2 * (float)this.m_referPrice), Mathf.CeilToInt((float)this.m_referPrice * num3), this.m_referPrice, step, false, false);
			bool flag2 = this.m_curBillStyle == AuctionBillStyle.PutAway;
			if (flag2)
			{
				base.uiBehaviour.m_CountOperate.Set((itemConf.AuctionUpperLimit == 0) ? this.m_curItem.itemCount : Mathf.Min(this.m_curItem.itemCount, (int)itemConf.AuctionUpperLimit), 1, 1, 1, true, false);
				base.uiBehaviour.m_CountOperate.SetEnable(true);
			}
			else
			{
				base.uiBehaviour.m_CountOperate.Set(this.m_curItem.itemCount, 1, this.m_curItem.itemCount, 1, true, false);
				base.uiBehaviour.m_CountOperate.SetEnable(false);
			}
			XSingleton<XItemDrawerMgr>.singleton.DrawItem(base.uiBehaviour.m_ItemTpl, this.m_curItem);
			base.uiBehaviour.m_iconSprite.ID = this.m_curItem.uid;
			base.uiBehaviour.m_iconSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemClick));
			base.uiBehaviour.m_ProcedurePrice.SetText(XSingleton<XGlobalConfig>.singleton.GetValue("AuctOnSaleCostGold"));
			base.uiBehaviour.m_sellOper.Reposition();
		}

		private void OnItemClick(IXUISprite sprite)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(this.m_curItem, null, sprite, false, 0U);
		}

		private void OnTotalPriceOperateChange()
		{
			int num = base.uiBehaviour.m_SinglePriceOperate.Cur * base.uiBehaviour.m_CountOperate.Cur;
			base.uiBehaviour.m_TotalPrice.SetText(num.ToString());
			int num2 = Mathf.Abs(base.uiBehaviour.m_SinglePriceOperate.Cur - this.m_referPrice);
			float num3 = 0f;
			bool flag = this.m_referPrice != 0;
			if (flag)
			{
				num3 = (float)num2 / (float)this.m_referPrice;
			}
			int num4 = Mathf.FloorToInt(num3 * 100f);
			base.uiBehaviour.m_RecommondTxt.SetText(string.Format((base.uiBehaviour.m_SinglePriceOperate.Cur < this.m_referPrice) ? "-{0}%" : "+{0}%", num4));
		}

		private bool OnClickLeftHandler(IXUIButton btn)
		{
			AuctionDocument specificDocument = XDocuments.GetSpecificDocument<AuctionDocument>(AuctionDocument.uuID);
			AuctionBillStyle curBillStyle = this.m_curBillStyle;
			if (curBillStyle != AuctionBillStyle.RePutAway)
			{
				if (curBillStyle == AuctionBillStyle.OutTime)
				{
					specificDocument.RequestAuctionQuitSale(this.m_aucuid);
				}
			}
			else
			{
				specificDocument.RequestAuctionQuitSale(this.m_aucuid);
			}
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnClickRightHandler(IXUIButton btn)
		{
			AuctionDocument specificDocument = XDocuments.GetSpecificDocument<AuctionDocument>(AuctionDocument.uuID);
			AuctionBillStyle curBillStyle = this.m_curBillStyle;
			if (curBillStyle != AuctionBillStyle.PutAway)
			{
				if (curBillStyle - AuctionBillStyle.RePutAway <= 1)
				{
					specificDocument.RequestAcutionReSale(this.m_aucuid, (uint)base.uiBehaviour.m_SinglePriceOperate.Cur);
				}
			}
			else
			{
				specificDocument.RequestAuctionSale(this.m_curItem.uid, (uint)this.m_curItem.itemID, (uint)base.uiBehaviour.m_CountOperate.Cur, (uint)base.uiBehaviour.m_SinglePriceOperate.Cur, this.m_curItem.Treasure);
			}
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnClickCloseHandler(IXUIButton sprite)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private Dictionary<AuctionBillStyle, string[]> m_billStyles;

		private AuctionBillStyle m_curBillStyle = AuctionBillStyle.PutAway;

		private int m_referPrice = 0;

		private ulong m_aucuid = 0UL;

		private XItem m_curItem;
	}
}
