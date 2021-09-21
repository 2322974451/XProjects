using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017F5 RID: 6133
	internal class FashionStorageEffectFrame : DlgHandlerBase
	{
		// Token: 0x0600FE57 RID: 65111 RVA: 0x003BCA40 File Offset: 0x003BAC40
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			this._Close = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this._Message = (base.transform.Find("Message").GetComponent("XUILabel") as IXUILabel);
			this._Content = (base.transform.Find("t").GetComponent("XUILabel") as IXUILabel);
			this._EditPortrait = (base.transform.Find("EditPortrait").GetComponent("XUIButton") as IXUIButton);
			this._ScrollView = (base.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this._WrapContent = (base.transform.Find("ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._EffectWrapContent));
			this._Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._CloseClick));
			this._EditPortrait.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnEditPortrait));
		}

		// Token: 0x0600FE58 RID: 65112 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x0600FE59 RID: 65113 RVA: 0x003BCB8C File Offset: 0x003BAD8C
		protected override void OnHide()
		{
			bool flag = this._doc.preview == FashionStoragePreview.Effect;
			if (flag)
			{
				this._doc.preview = FashionStoragePreview.None;
				this._doc.previewEffectID = 0U;
				DlgBase<FashionStorageDlg, FashionStorageBehaviour>.singleton.ShowAvatar();
			}
			base.OnHide();
		}

		// Token: 0x0600FE5A RID: 65114 RVA: 0x003BCBD8 File Offset: 0x003BADD8
		public override void RefreshData()
		{
			this._ActivateSuits = this._doc.GetActivateSuits();
			this._WrapContent.SetContentCount((this._ActivateSuits == null) ? 0 : this._ActivateSuits.Count, false);
			this._ScrollView.ResetPosition();
			this.ShowActivateSuitPortrait();
		}

		// Token: 0x0600FE5B RID: 65115 RVA: 0x003BCC30 File Offset: 0x003BAE30
		private void _EffectWrapContent(Transform tr, int index)
		{
			Transform transform = tr.Find("detal");
			IXUISprite ixuisprite = tr.GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = tr.Find("Name").GetComponent("XUILabel") as IXUILabel;
			bool flag = index >= XFashionStorageDocument.SpecialEffectIDs.Length;
			if (flag)
			{
				transform.gameObject.SetActive(false);
				ixuisprite.SetEnabled(false);
				ixuilabel.SetText("");
			}
			else
			{
				ixuisprite.SetEnabled(true);
				IFashionStorageSelect fashionStorageSelect = this._ActivateSuits[index];
				IXUICheckBox ixuicheckBox = transform.GetComponent("XUICheckBox") as IXUICheckBox;
				IXUISprite ixuisprite2 = transform.Find("Color").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite3 = transform.Find("Lock").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite4 = transform.Find("Selected").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite5 = transform.Find("Select").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite6 = transform.Find("RedPoint").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)fashionStorageSelect.GetID());
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnSelectEffect));
				FashionSuitSpecialEffects.RowData specialEffect = XFashionStorageDocument.GetSpecialEffect((uint)fashionStorageSelect.GetID());
				ixuilabel.SetText(fashionStorageSelect.GetName());
				ixuisprite6.SetVisible(fashionStorageSelect.RedPoint);
				string[] array = string.IsNullOrEmpty(specialEffect.Icon) ? null : specialEffect.Icon.Split(XGlobalConfig.SequenceSeparator);
				bool flag2 = array != null;
				if (flag2)
				{
					bool flag3 = array.Length > 1;
					if (flag3)
					{
						ixuisprite2.SetSprite(array[1], array[0], false);
					}
					else
					{
						bool flag4 = array.Length != 0;
						if (flag4)
						{
							ixuisprite2.SetSprite(array[0]);
						}
						else
						{
							ixuisprite2.SetSprite(null, null, false);
						}
					}
				}
				bool flag5 = this._doc.selfEffectID == specialEffect.suitid;
				if (flag5)
				{
					ixuisprite4.SetAlpha(1f);
					ixuicheckBox.bChecked = true;
					this._SelectEffectID = specialEffect.suitid;
				}
				else
				{
					ixuisprite4.SetAlpha(0f);
				}
				ixuisprite5.SetAlpha((this._SelectEffectID == specialEffect.suitid) ? 1f : 0f);
				ixuisprite3.SetVisible(!this._doc.isActivateEffect(specialEffect.suitid));
			}
		}

		// Token: 0x0600FE5C RID: 65116 RVA: 0x003BCEB4 File Offset: 0x003BB0B4
		private bool _CloseClick(IXUIButton btn)
		{
			DlgBase<FashionStorageDlg, FashionStorageBehaviour>.singleton.Switch(FashionStoragePreview.None);
			return true;
		}

		// Token: 0x0600FE5D RID: 65117 RVA: 0x003BCED4 File Offset: 0x003BB0D4
		private bool _OnEditPortrait(IXUIButton btn)
		{
			this._doc.GetActiveSuitEffect(this._SelectEffectID);
			return true;
		}

		// Token: 0x0600FE5E RID: 65118 RVA: 0x003BCEFC File Offset: 0x003BB0FC
		private void _OnSelectEffect(IXUISprite sprite)
		{
			this._SelectEffectID = (uint)sprite.ID;
			IXUICheckBox ixuicheckBox = sprite.transform.Find("detal").GetComponent("XUICheckBox") as IXUICheckBox;
			bool flag = ixuicheckBox != null;
			if (flag)
			{
				ixuicheckBox.bChecked = true;
			}
			bool flag2 = this._doc.isActivateEffect(this._SelectEffectID);
			if (flag2)
			{
				this._EditPortrait.SetVisible(false);
				this._doc.preview = FashionStoragePreview.None;
				this._doc.GetActiveSuitEffect(this._SelectEffectID);
			}
			else
			{
				this._doc.preview = FashionStoragePreview.Effect;
				this._doc.previewEffectID = this._SelectEffectID;
				DlgBase<FashionStorageDlg, FashionStorageBehaviour>.singleton.ShowAvatar();
			}
			this.ShowActivateSuitPortrait();
		}

		// Token: 0x0600FE5F RID: 65119 RVA: 0x003BCFBC File Offset: 0x003BB1BC
		private void ShowActivateSuitPortrait()
		{
			this._activateSuit = this._doc.GetActivateSuit(this._SelectEffectID);
			this._EditPortrait.SetVisible(this._activateSuit != null && this._activateSuit.RedPoint);
			bool flag = this._activateSuit == null || this._activateSuit.Active;
			if (flag)
			{
				this._Content.SetText("");
			}
			else
			{
				this._Content.SetText(XStringDefineProxy.GetString("FASHION_STORAGE_EFFECT_CONTENT", new object[]
				{
					this._activateSuit.GetName()
				}));
			}
		}

		// Token: 0x0600FE60 RID: 65120 RVA: 0x003BD05C File Offset: 0x003BB25C
		public override void OnUnload()
		{
			bool flag = this._doc.preview == FashionStoragePreview.Effect;
			if (flag)
			{
				this._doc.preview = FashionStoragePreview.None;
				this._doc.previewEffectID = 0U;
			}
			base.OnUnload();
		}

		// Token: 0x04007057 RID: 28759
		private IXUIButton _Close;

		// Token: 0x04007058 RID: 28760
		private IXUIButton _EditPortrait;

		// Token: 0x04007059 RID: 28761
		private IXUILabel _Message;

		// Token: 0x0400705A RID: 28762
		private IXUIScrollView _ScrollView;

		// Token: 0x0400705B RID: 28763
		private IXUIWrapContent _WrapContent;

		// Token: 0x0400705C RID: 28764
		private XBetterList<IFashionStorageSelect> _ActivateSuits;

		// Token: 0x0400705D RID: 28765
		private uint _SelectEffectID = 0U;

		// Token: 0x0400705E RID: 28766
		private XFashionStorageDocument _doc;

		// Token: 0x0400705F RID: 28767
		private IFashionStorageSelect _activateSuit;

		// Token: 0x04007060 RID: 28768
		private IXUILabel _Content;
	}
}
