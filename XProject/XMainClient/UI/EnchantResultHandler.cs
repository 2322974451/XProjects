using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017BE RID: 6078
	internal class EnchantResultHandler : DlgHandlerBase
	{
		// Token: 0x17003887 RID: 14471
		// (get) Token: 0x0600FBA8 RID: 64424 RVA: 0x003A7894 File Offset: 0x003A5A94
		protected override string FileName
		{
			get
			{
				return "ItemNew/EnchantResultPanel";
			}
		}

		// Token: 0x0600FBA9 RID: 64425 RVA: 0x003A78AB File Offset: 0x003A5AAB
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XEnchantDocument>(XEnchantDocument.uuID);
			this._doc._EnchantResultHandler = this;
			this.InitProperties();
		}

		// Token: 0x0600FBAA RID: 64426 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600FBAB RID: 64427 RVA: 0x003A78D8 File Offset: 0x003A5AD8
		protected override void OnShow()
		{
			base.OnShow();
			this._doc.ReqEnchant();
		}

		// Token: 0x0600FBAC RID: 64428 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600FBAD RID: 64429 RVA: 0x003A78EE File Offset: 0x003A5AEE
		public override void OnUnload()
		{
			this._doc._EnchantResultHandler = null;
			this._doc = null;
			base.OnUnload();
		}

		// Token: 0x0600FBAE RID: 64430 RVA: 0x0035654D File Offset: 0x0035474D
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshData();
		}

		// Token: 0x0600FBAF RID: 64431 RVA: 0x003A790C File Offset: 0x003A5B0C
		public override void RefreshData()
		{
			base.RefreshData();
			XEquipItem xequipItem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this._doc.SelectedEquipUID) as XEquipItem;
			bool flag = xequipItem == null;
			if (flag)
			{
				base.SetVisible(false);
			}
			else
			{
				this._curEnchantInfo = xequipItem.enchantInfo;
				this._RefreshCost();
				this._wrapContent.SetContentCount(this._curEnchantInfo.AttrList.Count, false);
				this._scrollView.ResetPosition();
			}
		}

		// Token: 0x0600FBB0 RID: 64432 RVA: 0x003A7998 File Offset: 0x003A5B98
		private void InitProperties()
		{
			IXUIButton ixuibutton = base.PanelObject.transform.Find("Bottom/BtnOK").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.ContinueToEnchant));
			this.m_uiCostValue = (base.transform.Find("Bottom/Cost").GetComponent("XUILabel") as IXUILabel);
			this.m_uiCostIcon = (base.transform.Find("Bottom/Cost/Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_Close = (base.transform.Find("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClose));
			this._equipItem = base.transform.Find("Top/EquipItem").gameObject;
			this._enchantIcon = (base.transform.Find("Bottom/CostStone/Icon").GetComponent("XUISprite") as IXUISprite);
			this._accessBtn = (base.transform.Find("Bottom/BtnGet").GetComponent("XUIButton") as IXUIButton);
			this._accessBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ToAccesss));
			this._costStone = (base.transform.Find("Bottom/CostStone").GetComponent("XUILabel") as IXUILabel);
			this._wrapContent = (base.transform.Find("Detail/wrapcontent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UpdateWrapContent));
			this._scrollView = (base.transform.Find("Detail").GetComponent("XUIScrollView") as IXUIScrollView);
		}

		// Token: 0x0600FBB1 RID: 64433 RVA: 0x003A7B6C File Offset: 0x003A5D6C
		private void UpdateWrapContent(Transform itemTransform, int index)
		{
			bool flag = index >= this._curEnchantInfo.AttrList.Count;
			if (!flag)
			{
				GameObject gameObject = itemTransform.Find("New").gameObject;
				IXUILabel ixuilabel = itemTransform.GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = itemTransform.Find("Right").GetComponent("XUILabel") as IXUILabel;
				GameObject gameObject2 = itemTransform.Find("Jt/Up").gameObject;
				GameObject gameObject3 = itemTransform.Find("Jt/Down").gameObject;
				GameObject gameObject4 = itemTransform.Find("Jt/unchanged").gameObject;
				gameObject2.SetActive(false);
				gameObject3.SetActive(false);
				gameObject4.SetActive(false);
				gameObject.SetActive(false);
				XItemChangeAttr xitemChangeAttr = this._curEnchantInfo.AttrList[index];
				string text = XAttributeCommon.GetAttrStr((int)xitemChangeAttr.AttrID) + "+" + xitemChangeAttr.AttrValue;
				bool flag2 = xitemChangeAttr.AttrID == this._doc.LastEnchantAttr.AttrID;
				if (flag2)
				{
					int changedPreAttrValue = this.GetChangedPreAttrValue();
					gameObject.SetActive(changedPreAttrValue < 0);
					bool flag3 = changedPreAttrValue >= 0;
					if (flag3)
					{
						gameObject4.gameObject.SetActive((long)changedPreAttrValue == (long)((ulong)this._doc.LastEnchantAttr.AttrValue));
						gameObject2.SetActive((long)changedPreAttrValue < (long)((ulong)this._doc.LastEnchantAttr.AttrValue));
						gameObject3.SetActive((long)changedPreAttrValue > (long)((ulong)this._doc.LastEnchantAttr.AttrValue));
						bool flag4 = (long)changedPreAttrValue < (long)((ulong)this._doc.LastEnchantAttr.AttrValue);
						if (flag4)
						{
							text = string.Concat(new object[]
							{
								"[00ff00]",
								text,
								" ",
								(long)((ulong)this._doc.LastEnchantAttr.AttrValue - (ulong)((long)changedPreAttrValue)),
								"[-]"
							});
						}
						else
						{
							bool flag5 = (long)changedPreAttrValue > (long)((ulong)this._doc.LastEnchantAttr.AttrValue);
							if (flag5)
							{
								text = string.Concat(new object[]
								{
									text,
									" [ff0000]",
									(long)changedPreAttrValue - (long)((ulong)this._doc.LastEnchantAttr.AttrValue),
									"[-]"
								});
							}
						}
					}
				}
				string text2 = "";
				EnchantEquip.RowData enchantEquipData = this._doc.GetEnchantEquipData(this._doc.SelectedItemID);
				bool flag6 = enchantEquipData != null;
				if (flag6)
				{
					for (int i = 0; i < (int)enchantEquipData.Attribute.count; i++)
					{
						bool flag7 = enchantEquipData.Attribute[i, 0] == xitemChangeAttr.AttrID;
						if (flag7)
						{
							text2 = string.Concat(new object[]
							{
								" [",
								enchantEquipData.Attribute[i, 1],
								",",
								enchantEquipData.Attribute[i, 2],
								"]"
							});
							break;
						}
					}
				}
				ixuilabel.SetText(text);
				ixuilabel2.SetText(text2);
			}
		}

		// Token: 0x0600FBB2 RID: 64434 RVA: 0x003A7EAC File Offset: 0x003A60AC
		private bool ToAccesss(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess(240, null);
			return true;
		}

		// Token: 0x0600FBB3 RID: 64435 RVA: 0x003A7ED0 File Offset: 0x003A60D0
		private bool ContinueToEnchant(IXUIButton button)
		{
			bool flag = !this.m_ItemRequiredCollector.bItemsEnough;
			bool result;
			if (flag)
			{
				for (int i = 0; i < this.m_ItemRequiredCollector.RequiredItems.Count; i++)
				{
					bool flag2 = !this.m_ItemRequiredCollector.RequiredItems[i].bEnough;
					if (flag2)
					{
						DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ShowBorad(this.m_ItemRequiredCollector.RequiredItems[i].itemID);
						break;
					}
				}
				result = true;
			}
			else
			{
				XEquipItem xequipItem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this._doc.SelectedEquipUID) as XEquipItem;
				bool flag3 = xequipItem == null;
				if (flag3)
				{
					result = true;
				}
				else
				{
					this._doc.ReqEnchant();
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600FBB4 RID: 64436 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void OnClose(IXUISprite uiSprite)
		{
			base.SetVisible(false);
		}

		// Token: 0x0600FBB5 RID: 64437 RVA: 0x003A7FA4 File Offset: 0x003A61A4
		private void _RefreshCost()
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(this._doc.SelectedItemID);
			bool flag = itemConf != null;
			if (flag)
			{
				this._enchantIcon.SetSprite(itemConf.ItemIcon1[0]);
			}
			XEquipItem xequipItem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this._doc.SelectedEquipUID) as XEquipItem;
			bool flag2 = xequipItem != null;
			if (flag2)
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this._equipItem, xequipItem);
			}
			this.m_ItemRequiredCollector.Init();
			EnchantEquip.RowData enchantEquipData = this._doc.GetEnchantEquipData(this._doc.SelectedItemID);
			bool flag3 = enchantEquipData != null;
			if (flag3)
			{
				for (int i = 0; i < enchantEquipData.Cost.Count; i++)
				{
					XItemRequired requiredItem = this.m_ItemRequiredCollector.GetRequiredItem(enchantEquipData.Cost[i, 0], (ulong)enchantEquipData.Cost[i, 1], 1f);
					bool flag4 = requiredItem == null;
					if (!flag4)
					{
						this.m_uiCostValue.SetText(requiredItem.requiredCount.ToString());
						this.m_uiCostValue.SetColor(requiredItem.bEnough ? Color.white : Color.red);
						this.m_uiCostIcon.SetSprite(XBagDocument.GetItemSmallIcon(requiredItem.itemID, 0U));
					}
				}
			}
			XItemRequired requiredItem2 = this.m_ItemRequiredCollector.GetRequiredItem((uint)this._doc.SelectedItemID, (ulong)enchantEquipData.Num, 1f);
			ulong itemCount = XBagDocument.BagDoc.GetItemCount(this._doc.SelectedItemID);
			uint num = (enchantEquipData == null) ? 0U : enchantEquipData.Num;
			this._costStone.SetText(itemCount + "/" + num);
			this._costStone.SetColor((itemCount >= (ulong)num) ? Color.white : Color.red);
			this._costStone.gameObject.transform.Find("GetTip").gameObject.SetActive(itemCount < (ulong)num);
		}

		// Token: 0x0600FBB6 RID: 64438 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void RefreshAfterAttri()
		{
		}

		// Token: 0x0600FBB7 RID: 64439 RVA: 0x003A81C4 File Offset: 0x003A63C4
		private int GetChangedPreAttrValue()
		{
			XEnchantInfo preEnchantInfo = this._doc.GetPreEnchantInfo();
			XEnchantInfo curEnchantInfo = this._curEnchantInfo;
			int result = -1;
			uint attrID = this._doc.LastEnchantAttr.AttrID;
			for (int i = 0; i < preEnchantInfo.AttrList.Count; i++)
			{
				bool flag = preEnchantInfo.AttrList[i].AttrID == attrID;
				if (flag)
				{
					result = (int)preEnchantInfo.AttrList[i].AttrValue;
					break;
				}
			}
			return result;
		}

		// Token: 0x04006E79 RID: 28281
		private XEnchantDocument _doc = null;

		// Token: 0x04006E7A RID: 28282
		private GameObject _equipItem;

		// Token: 0x04006E7B RID: 28283
		private IXUISprite _enchantIcon;

		// Token: 0x04006E7C RID: 28284
		private IXUIButton _accessBtn;

		// Token: 0x04006E7D RID: 28285
		private XItemRequiredCollector m_ItemRequiredCollector = new XItemRequiredCollector();

		// Token: 0x04006E7E RID: 28286
		private IXUILabel _costStone;

		// Token: 0x04006E7F RID: 28287
		private IXUILabel m_uiCostValue;

		// Token: 0x04006E80 RID: 28288
		private IXUISprite m_uiCostIcon;

		// Token: 0x04006E81 RID: 28289
		private IXUISprite m_Close;

		// Token: 0x04006E82 RID: 28290
		private IXUIScrollView _scrollView;

		// Token: 0x04006E83 RID: 28291
		private IXUIWrapContent _wrapContent;

		// Token: 0x04006E84 RID: 28292
		private XEnchantInfo _curEnchantInfo;
	}
}
