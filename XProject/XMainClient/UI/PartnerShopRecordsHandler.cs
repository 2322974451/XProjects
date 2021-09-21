using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017F4 RID: 6132
	internal class PartnerShopRecordsHandler : DlgHandlerBase
	{
		// Token: 0x170038D9 RID: 14553
		// (get) Token: 0x0600FE49 RID: 65097 RVA: 0x003BC690 File Offset: 0x003BA890
		private XPartnerDocument m_doc
		{
			get
			{
				return XPartnerDocument.Doc;
			}
		}

		// Token: 0x170038DA RID: 14554
		// (get) Token: 0x0600FE4A RID: 65098 RVA: 0x003BC6A8 File Offset: 0x003BA8A8
		protected override string FileName
		{
			get
			{
				return "Partner/PartnerShopRecords";
			}
		}

		// Token: 0x0600FE4B RID: 65099 RVA: 0x003BC6C0 File Offset: 0x003BA8C0
		protected override void Init()
		{
			base.Init();
			this.m_doc.ShopRecordsHandler = this;
			this.m_closeBtn = (base.PanelObject.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.PanelObject.transform.FindChild("Panel");
			this.m_wrapContent = (transform.FindChild("Wrap").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_tipsGo = base.PanelObject.transform.FindChild("Tips").gameObject;
			this.m_wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		// Token: 0x0600FE4C RID: 65100 RVA: 0x003BC779 File Offset: 0x003BA979
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosedClicked));
		}

		// Token: 0x0600FE4D RID: 65101 RVA: 0x003BC79B File Offset: 0x003BA99B
		protected override void OnShow()
		{
			base.OnShow();
			this.FillDefault();
			this.m_doc.ReqShopRecords();
		}

		// Token: 0x0600FE4E RID: 65102 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600FE4F RID: 65103 RVA: 0x0022CCF0 File Offset: 0x0022AEF0
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600FE50 RID: 65104 RVA: 0x003BC7B8 File Offset: 0x003BA9B8
		public override void OnUnload()
		{
			this.m_doc.ShopRecordsHandler = null;
			base.OnUnload();
		}

		// Token: 0x0600FE51 RID: 65105 RVA: 0x003BC7CE File Offset: 0x003BA9CE
		private void FillDefault()
		{
			this.m_tipsGo.SetActive(true);
			this.m_wrapContent.gameObject.SetActive(false);
		}

		// Token: 0x0600FE52 RID: 65106 RVA: 0x003BC7F0 File Offset: 0x003BA9F0
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

		// Token: 0x0600FE53 RID: 65107 RVA: 0x003BC8A0 File Offset: 0x003BAAA0
		private void WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = index >= this.m_doc.ShopRecordList.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("index >= ShopRecordList.Count", null, null, null, null, null);
			}
			else
			{
				partnerShopRecord partnerShopRecord = this.m_doc.ShopRecordList[index];
				IXUILabel ixuilabel = t.FindChild("Time").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(partnerShopRecord.TimeStr.Replace("/n", "\n"));
				ixuilabel = (t.FindChild("ItemName").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(partnerShopRecord.ItemName);
				ixuilabel = (t.FindChild("ItemNum").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(partnerShopRecord.BuyCount.ToString());
				IXUILabelSymbol ixuilabelSymbol = t.FindChild("PlayerName").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				ixuilabelSymbol.InputText = partnerShopRecord.PlayerName;
				ixuilabelSymbol.ID = (ulong)((long)index);
				ixuilabelSymbol.RegisterSymbolClickHandler(new LabelSymbolClickEventHandler(this.OnClickName));
			}
		}

		// Token: 0x0600FE54 RID: 65108 RVA: 0x003BC9CC File Offset: 0x003BABCC
		private bool OnClosedClicked(IXUIButton sp)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600FE55 RID: 65109 RVA: 0x003BC9E8 File Offset: 0x003BABE8
		private void OnClickName(IXUILabelSymbol iSp)
		{
			bool flag = this.m_doc.ShopRecordList == null;
			if (!flag)
			{
				int index = (int)iSp.ID / 100;
				partnerShopRecord partnerShopRecord = this.m_doc.ShopRecordList[index];
				bool flag2 = partnerShopRecord == null;
				if (!flag2)
				{
					XCharacterCommonMenuDocument.ReqCharacterMenuInfo(partnerShopRecord.RoleId, false);
				}
			}
		}

		// Token: 0x04007054 RID: 28756
		private IXUIButton m_closeBtn;

		// Token: 0x04007055 RID: 28757
		private IXUIWrapContent m_wrapContent;

		// Token: 0x04007056 RID: 28758
		private GameObject m_tipsGo;
	}
}
