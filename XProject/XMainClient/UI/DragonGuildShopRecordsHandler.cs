using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class DragonGuildShopRecordsHandler : DlgHandlerBase
	{

		private XDragonGuildDocument m_doc
		{
			get
			{
				return XDragonGuildDocument.Doc;
			}
		}

		protected override string FileName
		{
			get
			{
				return "Partner/PartnerShopRecords";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosedClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_doc.ReqShopRecords();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		public override void OnUnload()
		{
			this.m_doc.ShopRecordsHandler = null;
			base.OnUnload();
		}

		private void FillDefault()
		{
			this.m_tipsGo.SetActive(true);
			this.m_wrapContent.gameObject.SetActive(false);
		}

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

		private bool OnClosedClicked(IXUIButton sp)
		{
			base.SetVisible(false);
			return true;
		}

		private IXUIButton m_closeBtn;

		private IXUIWrapContent m_wrapContent;

		private GameObject m_tipsGo;

		private IXUIScrollView m_ScrollView;
	}
}
