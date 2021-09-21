using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016DA RID: 5850
	internal class DragonGuildShopRecordsHandler : DlgHandlerBase
	{
		// Token: 0x1700374A RID: 14154
		// (get) Token: 0x0600F146 RID: 61766 RVA: 0x00353AD0 File Offset: 0x00351CD0
		private XDragonGuildDocument m_doc
		{
			get
			{
				return XDragonGuildDocument.Doc;
			}
		}

		// Token: 0x1700374B RID: 14155
		// (get) Token: 0x0600F147 RID: 61767 RVA: 0x00353AE8 File Offset: 0x00351CE8
		protected override string FileName
		{
			get
			{
				return "Partner/PartnerShopRecords";
			}
		}

		// Token: 0x0600F148 RID: 61768 RVA: 0x00353B00 File Offset: 0x00351D00
		protected override void Init()
		{
			base.Init();
			this.m_doc.ShopRecordsHandler = this;
			this.m_closeBtn = (base.PanelObject.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.PanelObject.transform.FindChild("Panel");
			this.m_ScrollView = (transform.GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_wrapContent = (transform.FindChild("Wrap").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_tipsGo = base.PanelObject.transform.FindChild("Tips").gameObject;
			this.m_ScrollView.ResetPosition();
			this.m_wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		// Token: 0x0600F149 RID: 61769 RVA: 0x00353BDB File Offset: 0x00351DDB
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosedClicked));
		}

		// Token: 0x0600F14A RID: 61770 RVA: 0x00353BFD File Offset: 0x00351DFD
		protected override void OnShow()
		{
			base.OnShow();
			this.m_doc.ReqShopRecords();
		}

		// Token: 0x0600F14B RID: 61771 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600F14C RID: 61772 RVA: 0x0022CCF0 File Offset: 0x0022AEF0
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600F14D RID: 61773 RVA: 0x00353C13 File Offset: 0x00351E13
		public override void OnUnload()
		{
			this.m_doc.ShopRecordsHandler = null;
			base.OnUnload();
		}

		// Token: 0x0600F14E RID: 61774 RVA: 0x00353C29 File Offset: 0x00351E29
		private void FillDefault()
		{
			this.m_tipsGo.SetActive(true);
			this.m_wrapContent.gameObject.SetActive(false);
		}

		// Token: 0x0600F14F RID: 61775 RVA: 0x00353C4C File Offset: 0x00351E4C
		public void FillContent()
		{
			bool flag = this.m_doc.ShopRecordList == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("ShopRecordList is null", null, null, null, null, null);
			}
			else
			{
				bool flag2 = this.m_doc.ShopRecordList.Count == 0;
				if (flag2)
				{
					this.m_tipsGo.SetActive(true);
					this.m_wrapContent.gameObject.SetActive(false);
				}
				else
				{
					this.m_tipsGo.SetActive(false);
					this.m_wrapContent.gameObject.SetActive(true);
					int count = this.m_doc.ShopRecordList.Count;
					this.m_wrapContent.SetContentCount(count, false);
				}
			}
		}

		// Token: 0x0600F150 RID: 61776 RVA: 0x00353CFC File Offset: 0x00351EFC
		private void WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = index >= this.m_doc.ShopRecordList.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("index >= ShopRecordList.Count", null, null, null, null, null);
			}
			else
			{
				DragonGuildShopRecord dragonGuildShopRecord = this.m_doc.ShopRecordList[index];
				IXUILabel ixuilabel = t.FindChild("Time").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(dragonGuildShopRecord.TimeStr.Replace("/n", "\n"));
				ixuilabel = (t.FindChild("ItemName").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(dragonGuildShopRecord.ItemName);
				ixuilabel = (t.FindChild("ItemNum").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(dragonGuildShopRecord.BuyCount.ToString());
				IXUILabelSymbol ixuilabelSymbol = t.FindChild("PlayerName").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				ixuilabelSymbol.InputText = dragonGuildShopRecord.PlayerName;
				ixuilabelSymbol.ID = (ulong)((long)index);
				ixuilabelSymbol.RegisterSymbolClickHandler(new LabelSymbolClickEventHandler(this.OnClickName));
			}
		}

		// Token: 0x0600F151 RID: 61777 RVA: 0x00353E28 File Offset: 0x00352028
		private void OnClickName(IXUILabelSymbol iSp)
		{
			bool flag = this.m_doc.ShopRecordList == null;
			if (!flag)
			{
				int index = (int)iSp.ID / 100;
				DragonGuildShopRecord dragonGuildShopRecord = this.m_doc.ShopRecordList[index];
				bool flag2 = dragonGuildShopRecord == null;
				if (!flag2)
				{
					XCharacterCommonMenuDocument.ReqCharacterMenuInfo(dragonGuildShopRecord.RoleId, false);
				}
			}
		}

		// Token: 0x0600F152 RID: 61778 RVA: 0x00353E80 File Offset: 0x00352080
		private bool OnClosedClicked(IXUIButton sp)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x04006711 RID: 26385
		private IXUIButton m_closeBtn;

		// Token: 0x04006712 RID: 26386
		private IXUIWrapContent m_wrapContent;

		// Token: 0x04006713 RID: 26387
		private GameObject m_tipsGo;

		// Token: 0x04006714 RID: 26388
		private IXUIScrollView m_ScrollView;
	}
}
