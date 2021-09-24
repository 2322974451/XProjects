using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FashionStorageDlg : DlgBase<FashionStorageDlg, FashionStorageBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/FashionStorageDlg";
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			base.uiBehaviour.m_wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.ItemWrapContentUpdate));
			base.uiBehaviour.m_avatarSprite.RegisterSpriteDragEventHandler(new SpriteDragEventHandler(this.OnAvatarDrag));
			this.m_FashinListFrame = DlgHandlerBase.EnsureCreate<FashionStotageDisplayHandle>(ref this.m_FashinListFrame, base.uiBehaviour.m_fashionList, null, false);
			this.m_AttributeFrame = DlgHandlerBase.EnsureCreate<FashionStorageAttributeFrame>(ref this.m_AttributeFrame, base.uiBehaviour.m_attributeInfo, null, false);
			this.m_HairColorFrame = DlgHandlerBase.EnsureCreate<FashionStorageHairColorFrame>(ref this.m_HairColorFrame, base.uiBehaviour.m_hairFrame, null, false);
			this.m_effectFrame = DlgHandlerBase.EnsureCreate<FashionStorageEffectFrame>(ref this.m_effectFrame, base.uiBehaviour.m_effectFrame, null, false);
		}

		private void ItemWrapContentUpdate(Transform t, int index)
		{
			bool flag = this.m_SelectList == null || index >= this.m_SelectList.Count || this.m_SelectList[index] == null;
			if (!flag)
			{
				IFashionStorageSelect fashionStorageSelect = this.m_SelectList[index];
				IXUISprite ixuisprite = t.Find("Bg").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = t.Find("Bg/TextLabel").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite2 = t.Find("Bg/Selected").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel2 = t.Find("Bg/SelectedTextLabel").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite3 = t.Find("RedPoint").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel3 = t.Find("Count").GetComponent("XUILabel") as IXUILabel;
				Transform transform = t.Find("p");
				ixuisprite.ID = (ulong)((long)index);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectClick));
				string name = fashionStorageSelect.GetName();
				ixuilabel.SetText(name);
				ixuilabel2.SetText(name);
				float alpha = fashionStorageSelect.Select ? 1f : 0f;
				ixuilabel2.Alpha = alpha;
				ixuisprite2.SetAlpha(alpha);
				ixuisprite3.SetVisible(fashionStorageSelect.RedPoint);
				ixuilabel3.SetText(fashionStorageSelect.GetLabel());
				transform.gameObject.SetActive(fashionStorageSelect.GetItems().Count == fashionStorageSelect.GetFashionList().Length && this.m_doc.fashionStorageType > FashionStorageType.OutLook);
			}
		}

		public void Refresh()
		{
			this.OnTabChange(this.m_doc.fashionStorageType, true, false);
			bool flag = this.m_HairColorFrame != null && this.m_HairColorFrame.IsVisible();
			if (flag)
			{
				this.m_HairColorFrame.RefreshData();
			}
			bool flag2 = this.m_effectFrame != null && this.m_effectFrame.IsVisible();
			if (flag2)
			{
				this.m_effectFrame.RefreshData();
			}
			bool showEffect = this.m_doc.ShowEffect;
			if (showEffect)
			{
				XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_yh", base.uiBehaviour.transform, Vector3.zero, Vector3.one, 1f, true, 5f, true);
			}
		}

		private void RefreshRedPoint()
		{
			base.uiBehaviour.m_outLookRedPoint.SetVisible(this.m_doc.SuitRedPoint);
			base.uiBehaviour.m_fashionCharmRedPoint.SetVisible(this.m_doc.FashionRedPoint);
			base.uiBehaviour.m_equipCharmRedPoint.SetVisible(this.m_doc.EquipRedPoint);
			base.uiBehaviour.m_effectRedPoint.SetVisible(this.m_doc.fashionStorageType == FashionStorageType.OutLook && this.m_doc.SuitRedPoint);
		}

		private void SetSelectIndex(int index = -1)
		{
			bool flag = this.m_SelectList == null || this.m_SelectList.Count == 0;
			if (!flag)
			{
				bool flag2 = index > -1;
				if (flag2)
				{
					int i = 0;
					int count = this.m_SelectList.Count;
					while (i < count)
					{
						this.m_SelectList[i].Select = (i == index);
						i++;
					}
				}
				else
				{
					index = 0;
					bool flag3 = false;
					int j = 0;
					int count2 = this.m_SelectList.Count;
					while (j < count2)
					{
						bool select = this.m_SelectList[j].Select;
						if (select)
						{
							index = j;
							flag3 = true;
							break;
						}
						j++;
					}
					bool flag4 = !flag3;
					if (flag4)
					{
						this.m_SelectList[index].Select = true;
					}
				}
				base.uiBehaviour.m_wrapContent.RefreshAllVisibleContents();
				this.m_select = this.m_SelectList[index];
				this.OnReSelect();
			}
		}

		private void OnReSelect()
		{
			uint[] fashionList = this.m_select.GetFashionList();
			this.ShowAvatar(fashionList);
			this.SetPartInfo(fashionList);
			FashionStorageType fashionStorageType = this.m_doc.fashionStorageType;
			if (fashionStorageType != FashionStorageType.OutLook)
			{
				if (fashionStorageType - FashionStorageType.FashionCollection <= 1)
				{
					this.m_AttributeFrame.SetFashionCharm(this.m_select);
				}
			}
			else
			{
				this.m_FashinListFrame.SetFashionStorageSelect(this.m_select);
			}
		}

		private void SetupEffect(uint effectid)
		{
			bool flag = effectid == 0U;
			if (flag)
			{
				base.uiBehaviour.m_effectIcon.SetSprite(null, null, false);
			}
			else
			{
				FashionSuitSpecialEffects.RowData specialEffect = XFashionStorageDocument.GetSpecialEffect(effectid);
				bool flag2 = specialEffect == null;
				if (flag2)
				{
					base.uiBehaviour.m_effectIcon.SetSprite(null, null, false);
				}
				else
				{
					string[] array = string.IsNullOrEmpty(specialEffect.Icon) ? null : specialEffect.Icon.Split(XGlobalConfig.SequenceSeparator);
					bool flag3 = array != null;
					if (flag3)
					{
						bool flag4 = array.Length > 1;
						if (flag4)
						{
							base.uiBehaviour.m_effectIcon.SetSprite(array[1], array[0], false);
						}
						else
						{
							bool flag5 = array.Length != 0;
							if (flag5)
							{
								base.uiBehaviour.m_effectIcon.SetSprite(array[0]);
							}
							else
							{
								base.uiBehaviour.m_effectIcon.SetSprite(null, null, false);
							}
						}
					}
				}
			}
		}

		private void ReSetSelect()
		{
			this.ShowAvatar(null);
			this.SetPartInfo(null);
			FashionStorageType fashionStorageType = this.m_doc.fashionStorageType;
			if (fashionStorageType != FashionStorageType.OutLook)
			{
				if (fashionStorageType - FashionStorageType.FashionCollection <= 1)
				{
					this.m_AttributeFrame.SetFashionCharm(null);
				}
			}
			else
			{
				this.m_FashinListFrame.SetFashionStorageSelect(null);
			}
		}

		private void ShowFx(bool fx = false)
		{
			bool flag = this.m_fashionFx == null;
			if (flag)
			{
				this.m_fashionFx = XSingleton<XFxMgr>.singleton.CreateUIFx(this.m_fashionFxURL, base.uiBehaviour.m_effectContainer, false);
			}
		}

		private void DestroyFx()
		{
			bool flag = this.m_fashionFx == null;
			if (!flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_fashionFx, true);
				this.m_fashionFx = null;
			}
		}

		private void ResetNormalParts()
		{
			bool flag = this.allParts == null;
			if (flag)
			{
				this.allParts = new uint[XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FASHION_ALL_END)];
			}
			int i = 0;
			int num = this.allParts.Length;
			while (i < num)
			{
				this.allParts[i] = 0U;
				i++;
			}
		}

		private void SetPartInfo(uint[] part = null)
		{
			this.ResetNormalParts();
			bool flag = part != null;
			int i;
			int num;
			if (flag)
			{
				i = 0;
				num = part.Length;
				while (i < num)
				{
					uint num2 = part[i];
					FashionList.RowData fashionConf = XBagDocument.GetFashionConf((int)num2);
					bool flag2 = fashionConf != null;
					if (flag2)
					{
						this.allParts[(int)fashionConf.EquipPos] = num2;
					}
					else
					{
						EquipList.RowData equipConf = XBagDocument.GetEquipConf((int)num2);
						bool flag3 = equipConf != null;
						if (flag3)
						{
							this.allParts[(int)equipConf.EquipPos] = num2;
						}
					}
					i++;
				}
			}
			XItemDrawerMgr.Param.Reset();
			int num3 = XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.Hair);
			i = 0;
			num = this.allParts.Length;
			while (i < num)
			{
				uint num4 = this.allParts[i];
				bool flag4 = base.uiBehaviour.m_partList[i] == null;
				if (!flag4)
				{
					Transform transform = base.uiBehaviour.m_partList[i];
					IXUISprite ixuisprite = transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(ixuisprite.gameObject, (int)num4, 0, false);
					IXUISprite ixuisprite2 = transform.Find("unGet").GetComponent("XUISprite") as IXUISprite;
					IXUISprite ixuisprite3 = transform.Find("Icon/Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite3.ID = (ulong)num4;
					ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickPart));
					bool flag5 = num4 > 0U && (this.m_doc.fashionStorageType == FashionStorageType.EquipCollection || this.m_doc.fashionStorageType == FashionStorageType.FashionCollection);
					if (flag5)
					{
						bool flag6 = this.m_select != null && this.m_select.GetItems().Contains(num4);
						ixuisprite2.SetVisible(!flag6);
						ixuisprite.SetGrey(flag6);
					}
					else
					{
						ixuisprite2.SetVisible(false);
						ixuisprite.SetGrey(true);
					}
					bool flag7 = i == num3;
					if (flag7)
					{
						HairColorTable.RowData rowData = null;
						bool flag8 = num4 > 0U && this.m_doc.TryGetSelfHairColor(out rowData);
						if (flag8)
						{
							base.uiBehaviour.m_colorSprite.SetVisible(true);
							base.uiBehaviour.m_colorSprite.SetSprite(rowData.Icon);
							base.uiBehaviour.m_colorSprite.SetColor(XSingleton<UiUtility>.singleton.GetColor(rowData.Color));
							this.Switch(this.m_previewType);
						}
						else
						{
							base.uiBehaviour.m_colorSprite.SetVisible(false);
							bool flag9 = this.m_previewType == FashionStoragePreview.Hair;
							if (flag9)
							{
								this.Switch(FashionStoragePreview.None);
							}
						}
					}
				}
				i++;
			}
		}

		private void _EffectSpriteClick(IXUISprite sprite)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("_EffectSpriteClick", null, null, null, null, null);
			this.Switch(FashionStoragePreview.Effect);
		}

		private void OnClickPart(IXUISprite sprite)
		{
			bool flag = sprite.ID == 0UL;
			if (!flag)
			{
				int itemID = (int)sprite.ID;
				XItem item = XBagDocument.MakeXItem(itemID, true);
				XSingleton<UiUtility>.singleton.ShowOutLookDialog(item, null, 0U);
				XSingleton<XDebug>.singleton.AddGreenLog("sprite id :" + sprite.ID.ToString(), null, null, null, null, null);
			}
		}

		private void OnSelectClick(IXUISprite sprite)
		{
			this.Switch(FashionStoragePreview.None);
			this.SetSelectIndex((int)sprite.ID);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.m_outLook.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabClick));
			base.uiBehaviour.m_equipRecord.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabClick));
			base.uiBehaviour.m_fashionRecord.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabClick));
			base.uiBehaviour.m_effectSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._EffectSpriteClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("FashionStorageDlg");
			base.uiBehaviour.m_outLook.bChecked = true;
			this.Switch(FashionStoragePreview.None);
			this.ShowFx(true);
			this.OnTabChange(this.m_doc.fashionStorageType, true, true);
		}

		protected override void OnHide()
		{
			this.DestroyFx();
			this.m_previewType = FashionStoragePreview.None;
			bool flag = this.m_HairColorFrame != null;
			if (flag)
			{
				this.m_HairColorFrame.SetVisible(false);
			}
			bool flag2 = this.m_dummPool != -1;
			if (flag2)
			{
				XSingleton<X3DAvatarMgr>.singleton.DestroyDummy(this.m_dummPool, this.m_Dummy);
			}
			this.m_dummPool = -1;
			base.OnHide();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("FashionStorageDlg");
		}

		private OutLook outLook
		{
			get
			{
				bool flag = this.m_outLook == null;
				if (flag)
				{
					this.m_outLook = new OutLook();
				}
				bool flag2 = this.m_outLook.display_fashion == null;
				if (flag2)
				{
					this.m_outLook.display_fashion = new OutLookDisplayFashion();
				}
				return this.m_outLook;
			}
		}

		public void ShowAvatar()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this.m_select == null;
				if (flag2)
				{
					this.ShowAvatar(null);
				}
				else
				{
					this.ShowAvatar(this.m_select.GetFashionList());
				}
			}
		}

		private void ShowAvatar(uint[] fashionList = null)
		{
			this.outLook.display_fashion.display_fashions.Clear();
			this.m_dummyAngle.y = 180f;
			bool flag = fashionList != null;
			if (flag)
			{
				this.outLook.display_fashion.display_fashions.AddRange(fashionList);
			}
			bool flag2 = this.m_doc.fashionStorageType == FashionStorageType.OutLook;
			if (flag2)
			{
				bool flag3 = this.m_doc.preview == FashionStoragePreview.Hair;
				if (flag3)
				{
					this.outLook.display_fashion.hair_color_id = this.m_doc.previewHairColor;
				}
				else
				{
					this.outLook.display_fashion.hair_color_id = this.m_doc.selfHairColor;
				}
				bool flag4 = this.m_doc.preview == FashionStoragePreview.Effect;
				if (flag4)
				{
					this.outLook.display_fashion.special_effects_id = this.m_doc.previewEffectID;
				}
				else
				{
					this.outLook.display_fashion.special_effects_id = this.m_doc.selfEffectID;
				}
			}
			else
			{
				this.outLook.display_fashion.hair_color_id = 0U;
				this.outLook.display_fashion.special_effects_id = 0U;
			}
			XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
			uint unitType = (uint)XFastEnumIntEqualityComparer<RoleType>.ToInt(xplayerData.Profession);
			this.m_Dummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonRoleDummy(this.m_dummPool, xplayerData.RoleID, unitType, this.outLook, base.uiBehaviour.m_Snapshot, this.m_Dummy);
			bool flag5 = this.m_Dummy != null;
			if (flag5)
			{
				this.m_Dummy.EngineObject.LocalEulerAngles = this.m_dummyAngle;
			}
		}

		private bool OnAvatarDrag(Vector2 delta)
		{
			bool flag = this.m_Dummy != null;
			if (flag)
			{
				this.m_Dummy.EngineObject.Rotate(Vector2.up, -delta.x / 2f);
				this.m_dummyAngle = this.m_Dummy.EngineObject.LocalEulerAngles;
			}
			else
			{
				XSingleton<X3DAvatarMgr>.singleton.RotateMain(-delta.x / 2f);
			}
			return true;
		}

		protected override void OnUnload()
		{
			this.m_outLook = null;
			this.DestroyFx();
			bool flag = this.m_dummPool > -1;
			if (flag)
			{
				XSingleton<X3DAvatarMgr>.singleton.DestroyDummy(this.m_dummPool, this.m_Dummy);
			}
			this.m_dummPool = -1;
			DlgHandlerBase.EnsureUnload<FashionStotageDisplayHandle>(ref this.m_FashinListFrame);
			DlgHandlerBase.EnsureUnload<FashionStorageAttributeFrame>(ref this.m_AttributeFrame);
			DlgHandlerBase.EnsureUnload<FashionStorageHairColorFrame>(ref this.m_HairColorFrame);
			DlgHandlerBase.EnsureUnload<FashionStorageEffectFrame>(ref this.m_effectFrame);
			base.OnUnload();
		}

		private bool OnCloseClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

		private bool OnTabClick(IXUICheckBox check)
		{
			bool bChecked = check.bChecked;
			if (bChecked)
			{
				FashionStorageType define = (FashionStorageType)check.ID;
				this.Switch(FashionStoragePreview.None);
				this.OnTabChange(define, false, true);
			}
			return true;
		}

		private void OnTabChange(FashionStorageType define, bool atOnce = false, bool reset = false)
		{
			bool flag = !atOnce && define == this.m_doc.fashionStorageType;
			if (!flag)
			{
				this.m_doc.fashionStorageType = define;
				this.SwitchOutLook();
				this.m_AttributeFrame.SetVisible(define == FashionStorageType.FashionCollection || define == FashionStorageType.EquipCollection);
				this.m_doc.GetCollection(ref this.m_SelectList, define);
				base.uiBehaviour.m_wrapContent.SetContentCount(this.m_SelectList.Count, false);
				if (reset)
				{
					base.uiBehaviour.m_scrollView.ResetPosition();
				}
				bool flag2 = this.m_SelectList.Count > 0;
				if (flag2)
				{
					this.SetSelectIndex(-1);
				}
				else
				{
					this.ReSetSelect();
				}
			}
		}

		public void Switch(FashionStoragePreview preview)
		{
			bool flag = !base.IsVisible() || this.m_previewType == preview;
			if (!flag)
			{
				this.m_previewType = preview;
				this.SwitchOutLook();
			}
		}

		private void SwitchOutLook()
		{
			bool flag = this.m_doc.fashionStorageType == FashionStorageType.OutLook;
			this.m_HairColorFrame.SetVisible(flag && this.m_previewType == FashionStoragePreview.Hair);
			this.m_FashinListFrame.SetVisible(flag && this.m_previewType == FashionStoragePreview.None);
			this.m_effectFrame.SetVisible(flag && this.m_previewType == FashionStoragePreview.Effect);
			this.RefreshRedPoint();
			this.SetupEffect(flag ? this.m_doc.selfEffectID : 0U);
		}

		private XFashionStorageDocument m_doc;

		private List<IFashionStorageSelect> m_SelectList;

		private IFashionStorageSelect m_select;

		private FashionStotageDisplayHandle m_FashinListFrame;

		private FashionStorageAttributeFrame m_AttributeFrame;

		private FashionStorageHairColorFrame m_HairColorFrame;

		private FashionStorageEffectFrame m_effectFrame;

		private Vector3 m_dummyAngle = new Vector3(0f, 180f, 0f);

		private XFx m_fashionFx;

		private XDummy m_Dummy;

		private string m_fashionFxURL = "Effects/FX_Particle/UIfx/UI_UI_FashionStorageDlg_fx01";

		private FashionStoragePreview m_previewType = FashionStoragePreview.None;

		private uint[] allParts = null;

		private OutLook m_outLook;
	}
}
