using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class EnchantActiveHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "ItemNew/EnchantActivationPanel";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			this._doc._EnchantActiveHandler = null;
			base.OnUnload();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshData();
		}

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

		private void OnClose(IXUISprite uiSprite)
		{
			base.SetVisible(false);
		}

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

		private void _OnEquipIconClicked(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this._doc.SelectedEquipUID), null, iSp, false, 0U);
		}

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

		private void WrapContentInit(Transform itemTransform, int index)
		{
			IXUICheckBox ixuicheckBox = itemTransform.GetComponent("XUICheckBox") as IXUICheckBox;
			ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSelectAttributeItem));
		}

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

		private XEnchantDocument _doc = null;

		private IXUIWrapContent _wrapContent;

		private IXUIScrollView _scrollView;

		private uint _curSelectedAttribute;

		private XEnchantInfo _curEnchantInfo;

		private GameObject _uiEquipItem;

		private GameObject _emptyTag;
	}
}
