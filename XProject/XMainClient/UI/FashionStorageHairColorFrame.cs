using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FashionStorageHairColorFrame : DlgHandlerBase
	{

		protected override void Init()
		{
			this.m_Doc = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			this.m_Submit = (base.transform.Find("Submit").GetComponent("XUIButton") as IXUIButton);
			this.m_Close = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_EditPortrait = (base.transform.Find("EditPortrait").GetComponent("XUIButton") as IXUIButton);
			this.m_EditorPortraitLabel = (base.transform.Find("EditPortrait/T").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_ScrollView = (base.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.Find("ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_HairNameLabel = (base.transform.Find("HairName").GetComponent("XUILabel") as IXUILabel);
			this.m_MessageLabel = (base.transform.Find("Message").GetComponent("XUILabel") as IXUILabel);
			this.m_MessageLabel.SetText(XStringDefineProxy.GetString("FASHION_STORAGE_HARI_MESSAGE"));
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapContentUpdate));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		protected override void OnHide()
		{
			bool flag = this.m_Doc.preview == FashionStoragePreview.Hair;
			if (flag)
			{
				this.m_Doc.preview = FashionStoragePreview.None;
				this.m_Doc.previewHairColor = 0U;
				DlgBase<FashionStorageDlg, FashionStorageBehaviour>.singleton.ShowAvatar();
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FASHION_HAIRCOLOR_UNSAVE"), "fece00");
			}
			base.OnHide();
		}

		public override void OnUnload()
		{
			bool flag = (this.m_Doc.preview & FashionStoragePreview.Hair) == FashionStoragePreview.Hair;
			if (flag)
			{
				this.m_Doc.preview = FashionStoragePreview.None;
				this.m_Doc.previewHairColor = 0U;
			}
			base.OnUnload();
		}

		public override void RefreshData()
		{
			base.RefreshData();
			this.m_SelectHairData = this.m_Doc.GetFashionHair(this.m_Doc.selectHairID);
			this.m_HairNameLabel.SetText(this.m_SelectHairData.GetName());
			bool flag = this.m_SelectHairData == null;
			if (flag)
			{
				this.m_WrapContent.SetContentCount(0, false);
				this.m_MessageLabel.SetVisible(true);
			}
			else
			{
				this.m_WrapContent.SetContentCount(this.m_SelectHairData.GetFashionList().Length, false);
				this.m_MessageLabel.SetVisible(this.m_SelectHairData.GetFashionList().Length <= this.m_WrapContent.widthDimension * 2);
			}
			this.m_ScrollView.ResetPosition();
		}

		private void OnWrapContentUpdate(Transform tr, int index)
		{
			Transform transform = tr.Find("detal");
			IXUISprite ixuisprite = tr.GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = tr.Find("Name").GetComponent("XUILabel") as IXUILabel;
			bool flag = index >= this.m_SelectHairData.GetFashionList().Length;
			if (flag)
			{
				transform.gameObject.SetActive(false);
				ixuisprite.SetEnabled(false);
				ixuilabel.SetText("");
			}
			else
			{
				ixuisprite.SetEnabled(true);
				IXUICheckBox ixuicheckBox = transform.GetComponent("XUICheckBox") as IXUICheckBox;
				IXUISprite ixuisprite2 = transform.Find("Color").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite3 = transform.Find("Lock").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite4 = transform.Find("Selected").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite5 = transform.Find("Select").GetComponent("XUISprite") as IXUISprite;
				HairColorTable.RowData hairColorData = this.m_Doc.GetHairColorData(this.m_SelectHairData.GetFashionList()[index]);
				ixuisprite.ID = (ulong)hairColorData.ID;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectHairColor));
				ixuilabel.SetText(hairColorData.Name);
				ixuisprite2.SetColor(XSingleton<UiUtility>.singleton.GetColor(hairColorData.Color));
				bool flag2 = this.m_Doc.CurHairColor == hairColorData.ID;
				if (flag2)
				{
					ixuisprite4.SetAlpha(1f);
					ixuicheckBox.bChecked = true;
					this.m_SelectColorID = hairColorData.ID;
					this.ShowActivateHairPortrait();
				}
				else
				{
					ixuisprite4.SetAlpha(0f);
				}
				ixuisprite5.SetAlpha((this.m_SelectColorID == hairColorData.ID) ? 1f : 0f);
				ixuisprite3.SetVisible(!this.m_SelectHairData.GetItems().Contains(hairColorData.ID));
			}
		}

		private void OnSelectHairColor(IXUISprite sprite)
		{
			this.m_SelectColorID = (uint)sprite.ID;
			IXUICheckBox ixuicheckBox = sprite.transform.Find("detal").GetComponent("XUICheckBox") as IXUICheckBox;
			bool flag = ixuicheckBox != null;
			if (flag)
			{
				ixuicheckBox.bChecked = true;
			}
			bool flag2 = this.m_Doc.IsActivateHairColor(this.m_Doc.selectHairID, this.m_SelectColorID);
			if (flag2)
			{
				this.m_EditPortrait.SetVisible(false);
				this.m_Doc.preview = FashionStoragePreview.None;
				this.m_Doc.GetActivateHairColor(this.m_Doc.selectHairID, this.m_SelectColorID);
			}
			else
			{
				this.m_Doc.preview = FashionStoragePreview.Hair;
				this.m_Doc.previewHairColor = this.m_SelectColorID;
				DlgBase<FashionStorageDlg, FashionStorageBehaviour>.singleton.ShowAvatar();
			}
			this.ShowActivateHairPortrait();
		}

		private void ShowActivateHairPortrait()
		{
			uint num = default;
			uint cost = default;
			bool flag = !this.m_Doc.IsActivateHairColor(this.m_Doc.selectHairID, this.m_SelectColorID) && this.m_Doc.TryGetActivateUseItem(this.m_Doc.selectHairID, this.m_SelectColorID, out num, out cost);
			if (flag)
			{
				this.m_EditPortrait.SetVisible(true);
				this.m_EditorPortraitLabel.InputText = XSingleton<XCommon>.singleton.StringCombine(XLabelSymbolHelper.FormatCostWithIcon((int)cost, ItemEnum.HAIR_COLORING), "  ", XStringDefineProxy.GetString("HAIR_COULORING"));
			}
			else
			{
				this.m_EditPortrait.SetVisible(false);
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Submit.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSubmitHandle));
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseHandle));
			this.m_EditPortrait.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEditPortrait));
		}

		private bool OnCloseHandle(IXUIButton btn)
		{
			DlgBase<FashionStorageDlg, FashionStorageBehaviour>.singleton.Switch(FashionStoragePreview.None);
			return true;
		}

		private bool OnEditPortrait(IXUIButton btn)
		{
			this.m_Doc.GetActivateHairColor(this.m_Doc.selectHairID, this.m_Doc.previewHairColor);
			return true;
		}

		private bool OnSubmitHandle(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.HAIR_COLORING), null);
			return true;
		}

		private IXUIButton m_Submit;

		private IXUIButton m_Close;

		private IXUIButton m_EditPortrait;

		private IXUILabelSymbol m_EditorPortraitLabel;

		private IXUIScrollView m_ScrollView;

		private IXUIWrapContent m_WrapContent;

		private XFashionStorageDocument m_Doc;

		private uint m_SelectColorID = 0U;

		private IFashionStorageSelect m_SelectHairData;

		private IXUILabel m_HairNameLabel;

		private IXUILabel m_MessageLabel;
	}
}
