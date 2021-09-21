using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001719 RID: 5913
	internal class AuctionBillView : DlgBase<AuctionBillView, AuctionBillBehaviour>
	{
		// Token: 0x1700379F RID: 14239
		// (get) Token: 0x0600F423 RID: 62499 RVA: 0x0036B05C File Offset: 0x0036925C
		public override string fileName
		{
			get
			{
				return "GameSystem/Auction/AuctionBillFrame";
			}
		}

		// Token: 0x170037A0 RID: 14240
		// (get) Token: 0x0600F424 RID: 62500 RVA: 0x0036B074 File Offset: 0x00369274
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F425 RID: 62501 RVA: 0x0036B088 File Offset: 0x00369288
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

		// Token: 0x0600F426 RID: 62502 RVA: 0x0036B0C4 File Offset: 0x003692C4
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

		// Token: 0x0600F427 RID: 62503 RVA: 0x0036B1A8 File Offset: 0x003693A8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_LeftButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickLeftHandler));
			base.uiBehaviour.m_RightButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickRightHandler));
			base.uiBehaviour.m_SinglePriceOperate.RegisterOperateChange(new AuctionNumberOperate.NumberOperateCallBack(this.OnTotalPriceOperateChange));
			base.uiBehaviour.m_CountOperate.RegisterOperateChange(new AuctionNumberOperate.NumberOperateCallBack(this.OnTotalPriceOperateChange));
			base.uiBehaviour.m_CloseButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickCloseHandler));
		}

		// Token: 0x0600F428 RID: 62504 RVA: 0x0036B24E File Offset: 0x0036944E
		protected override void OnShow()
		{
			base.OnShow();
			this.SetDetailInfo();
		}

		// Token: 0x0600F429 RID: 62505 RVA: 0x0036B260 File Offset: 0x00369460
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

		// Token: 0x0600F42A RID: 62506 RVA: 0x0036B506 File Offset: 0x00369706
		private void OnItemClick(IXUISprite sprite)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(this.m_curItem, null, sprite, false, 0U);
		}

		// Token: 0x0600F42B RID: 62507 RVA: 0x0036B520 File Offset: 0x00369720
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

		// Token: 0x0600F42C RID: 62508 RVA: 0x0036B5F4 File Offset: 0x003697F4
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

		// Token: 0x0600F42D RID: 62509 RVA: 0x0036B64C File Offset: 0x0036984C
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

		// Token: 0x0600F42E RID: 62510 RVA: 0x0036B6F0 File Offset: 0x003698F0
		private bool OnClickCloseHandler(IXUIButton sprite)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x04006913 RID: 26899
		private Dictionary<AuctionBillStyle, string[]> m_billStyles;

		// Token: 0x04006914 RID: 26900
		private AuctionBillStyle m_curBillStyle = AuctionBillStyle.PutAway;

		// Token: 0x04006915 RID: 26901
		private int m_referPrice = 0;

		// Token: 0x04006916 RID: 26902
		private ulong m_aucuid = 0UL;

		// Token: 0x04006917 RID: 26903
		private XItem m_curItem;
	}
}
