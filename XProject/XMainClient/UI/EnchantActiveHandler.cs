using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017BA RID: 6074
	internal class EnchantActiveHandler : DlgHandlerBase
	{
		// Token: 0x17003884 RID: 14468
		// (get) Token: 0x0600FB60 RID: 64352 RVA: 0x003A5B74 File Offset: 0x003A3D74
		protected override string FileName
		{
			get
			{
				return "ItemNew/EnchantActivationPanel";
			}
		}

		// Token: 0x0600FB61 RID: 64353 RVA: 0x003A5B8B File Offset: 0x003A3D8B
		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		// Token: 0x0600FB62 RID: 64354 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600FB63 RID: 64355 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x0600FB64 RID: 64356 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600FB65 RID: 64357 RVA: 0x003A5B9C File Offset: 0x003A3D9C
		public override void OnUnload()
		{
			this._doc._EnchantActiveHandler = null;
			base.OnUnload();
		}

		// Token: 0x0600FB66 RID: 64358 RVA: 0x0035654D File Offset: 0x0035474D
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshData();
		}

		// Token: 0x0600FB67 RID: 64359 RVA: 0x003A5BB4 File Offset: 0x003A3DB4
		public override void RefreshData()
		{
			base.RefreshData();
			XEquipItem xequipItem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this._doc.SelectedEquipUID) as XEquipItem;
			bool flag = xequipItem == null;
			if (!flag)
			{
				this._curSelectedAttribute = xequipItem.enchantInfo.ChooseAttr;
				this._curEnchantInfo = xequipItem.enchantInfo;
				this._wrapContent.SetContentCount(this._curEnchantInfo.AttrList.Count, false);
				this._scrollView.ResetPosition();
				this._emptyTag.SetActive(this._curEnchantInfo.AttrList.Count == 0);
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this._uiEquipItem, xequipItem);
			}
		}

		// Token: 0x0600FB68 RID: 64360 RVA: 0x003A5C70 File Offset: 0x003A3E70
		private void SetChooseAttrItem()
		{
			List<GameObject> list = new List<GameObject>();
			this._wrapContent.GetActiveList(list);
			for (int i = 0; i < list.Count; i++)
			{
				IXUICheckBox ixuicheckBox = list[i].GetComponent("XUICheckBox") as IXUICheckBox;
				bool flag = ixuicheckBox.ID == (ulong)this._curEnchantInfo.ChooseAttr;
				if (flag)
				{
					ixuicheckBox.bChecked = true;
					break;
				}
			}
		}

		// Token: 0x0600FB69 RID: 64361 RVA: 0x003A5CE4 File Offset: 0x003A3EE4
		private void InitProperties()
		{
			this._doc = XDocuments.GetSpecificDocument<XEnchantDocument>(XEnchantDocument.uuID);
			this._doc._EnchantActiveHandler = this;
			this._scrollView = (base.transform.Find("BagPanel").GetComponent("XUIScrollView") as IXUIScrollView);
			this._wrapContent = (base.transform.Find("BagPanel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._wrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.WrapContentInit));
			this._wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentUpdate));
			IXUIButton ixuibutton = base.transform.Find("BtnOk").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.ConfirmActiveAttribute));
			this._uiEquipItem = base.transform.Find("Top/EquipItem").gameObject;
			IXUISprite ixuisprite = this._uiEquipItem.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnEquipIconClicked));
			IXUISprite ixuisprite2 = base.transform.Find("Close").GetComponent("XUISprite") as IXUISprite;
			ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClose));
			this._emptyTag = base.transform.Find("Empty").gameObject;
		}

		// Token: 0x0600FB6A RID: 64362 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void OnClose(IXUISprite uiSprite)
		{
			base.SetVisible(false);
		}

		// Token: 0x0600FB6B RID: 64363 RVA: 0x003A5E5C File Offset: 0x003A405C
		private bool ConfirmActiveAttribute(IXUIButton button)
		{
			bool flag = this._curSelectedAttribute == 0U || this._curSelectedAttribute == this._curEnchantInfo.ChooseAttr;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this._doc.SendEnchantActiveAttribute(this._curSelectedAttribute);
				result = true;
			}
			return result;
		}

		// Token: 0x0600FB6C RID: 64364 RVA: 0x003A5EA7 File Offset: 0x003A40A7
		private void _OnEquipIconClicked(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this._doc.SelectedEquipUID), null, iSp, false, 0U);
		}

		// Token: 0x0600FB6D RID: 64365 RVA: 0x003A5ED8 File Offset: 0x003A40D8
		private void WrapContentUpdate(Transform itemTransform, int index)
		{
			bool flag = index >= this._curEnchantInfo.AttrList.Count;
			if (!flag)
			{
				XItemChangeAttr xitemChangeAttr = this._curEnchantInfo.AttrList[index];
				uint attrID = xitemChangeAttr.AttrID;
				uint attrValue = xitemChangeAttr.AttrValue;
				IXUICheckBox ixuicheckBox = itemTransform.GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox.ID = (ulong)attrID;
				IXUILabel ixuilabel = itemTransform.Find("Attr").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = itemTransform.Find("Attr/Value").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = itemTransform.Find("PPT").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(XAttributeCommon.GetAttrStr((int)attrID));
				ixuilabel2.SetText("+" + attrValue);
				bool flag2 = this._curSelectedAttribute == attrID;
				if (flag2)
				{
					ixuicheckBox.bChecked = true;
				}
				else
				{
					ixuicheckBox.ForceSetFlag(false);
				}
				double ppt = XSingleton<XPowerPointCalculator>.singleton.GetPPT(attrID, attrValue, null, -1);
				ixuilabel3.SetText(((int)ppt).ToString());
			}
		}

		// Token: 0x0600FB6E RID: 64366 RVA: 0x003A6000 File Offset: 0x003A4200
		private void WrapContentInit(Transform itemTransform, int index)
		{
			IXUICheckBox ixuicheckBox = itemTransform.GetComponent("XUICheckBox") as IXUICheckBox;
			ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSelectAttributeItem));
		}

		// Token: 0x0600FB6F RID: 64367 RVA: 0x003A6034 File Offset: 0x003A4234
		private bool OnSelectAttributeItem(IXUICheckBox iXUICheckBox)
		{
			bool flag = !iXUICheckBox.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._curSelectedAttribute = (uint)iXUICheckBox.ID;
				result = true;
			}
			return result;
		}

		// Token: 0x04006E4F RID: 28239
		private XEnchantDocument _doc = null;

		// Token: 0x04006E50 RID: 28240
		private IXUIWrapContent _wrapContent;

		// Token: 0x04006E51 RID: 28241
		private IXUIScrollView _scrollView;

		// Token: 0x04006E52 RID: 28242
		private uint _curSelectedAttribute;

		// Token: 0x04006E53 RID: 28243
		private XEnchantInfo _curEnchantInfo;

		// Token: 0x04006E54 RID: 28244
		private GameObject _uiEquipItem;

		// Token: 0x04006E55 RID: 28245
		private GameObject _emptyTag;
	}
}
