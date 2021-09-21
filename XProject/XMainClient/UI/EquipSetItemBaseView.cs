using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001822 RID: 6178
	internal class EquipSetItemBaseView
	{
		// Token: 0x060100B2 RID: 65714 RVA: 0x003D1E29 File Offset: 0x003D0029
		public void SetFinishItem(XItem item)
		{
			this.mXItemToShow = item;
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(this.goItem, item.itemID, new SpriteClickEventHandler(this._OnClickItemIcon));
		}

		// Token: 0x060100B3 RID: 65715 RVA: 0x003D1E5C File Offset: 0x003D005C
		public virtual void FindFrom(Transform t)
		{
			bool flag = null != t;
			if (flag)
			{
				Transform transform = t.Find("Level");
				bool flag2 = transform == null;
				if (flag2)
				{
					this.lbLevel = null;
				}
				else
				{
					this.lbLevel = (transform.GetComponent("XUILabel") as IXUILabel);
				}
				transform = t.Find("Prof");
				bool flag3 = transform == null;
				if (flag3)
				{
					this.lbProfName = null;
				}
				else
				{
					this.lbProfName = (transform.GetComponent("XUILabel") as IXUILabel);
				}
				transform = t.Find("Part");
				bool flag4 = transform == null;
				if (flag4)
				{
					this.lbPartName = null;
				}
				else
				{
					this.lbPartName = (transform.GetComponent("XUILabel") as IXUILabel);
				}
				this.goItem = t.Find("Item").gameObject;
				transform = t.Find("Item/Yyy");
				bool flag5 = transform != null;
				if (flag5)
				{
					this.goHadGet = transform.gameObject;
				}
				else
				{
					this.goHadGet = null;
				}
				transform = t.Find("Item/Name");
				int childCount = transform.childCount;
				bool flag6 = childCount > 0;
				if (flag6)
				{
					this.qualityEffectItemArr = new EquipSetItemBaseView.stQualityEffectItem[childCount];
					for (int i = 0; i < childCount; i++)
					{
						this.qualityEffectItemArr[i].effect = transform.GetChild(i).gameObject;
						this.qualityEffectItemArr[i].effect.SetActive(false);
						int.TryParse(this.qualityEffectItemArr[i].effect.name, out this.qualityEffectItemArr[i].quality);
					}
				}
				else
				{
					this.qualityEffectItemArr = null;
				}
			}
		}

		// Token: 0x060100B4 RID: 65716 RVA: 0x003D201C File Offset: 0x003D021C
		public void SetItemInfo(int _itemID, EquipSetItemBaseView.stEquipInfoParam _param, bool _isBind = false)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(_itemID);
			this.SetItemInfo(itemConf, _param, _isBind);
		}

		// Token: 0x060100B5 RID: 65717 RVA: 0x003D203C File Offset: 0x003D023C
		public void SetItemInfo(XItem item, EquipSetItemBaseView.stEquipInfoParam _param, bool _isBind = false)
		{
			bool flag = item == null;
			if (!flag)
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf(item.itemID);
				this.SetItemInfo(itemConf, _param, _isBind);
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.goItem, item);
			}
		}

		// Token: 0x060100B6 RID: 65718 RVA: 0x003D207C File Offset: 0x003D027C
		public void SetItemInfo(ItemList.RowData _item, EquipSetItemBaseView.stEquipInfoParam _param, bool _isBind = false)
		{
			bool flag = _item == null;
			if (!flag)
			{
				this.bBinding = _isBind;
				XItemDrawerMgr.Param.bBinding = _isBind;
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.goItem, _item.ItemID, 0, false);
				bool flag2 = true;
				bool flag3 = this.qualityEffectItemArr != null && _item != null;
				if (flag3)
				{
					for (int i = 0; i < this.qualityEffectItemArr.Length; i++)
					{
						bool flag4 = this.qualityEffectItemArr[i].quality == (int)_item.ItemQuality;
						if (flag4)
						{
							this.goCurrentEffect = this.qualityEffectItemArr[i].effect;
							flag2 = false;
							break;
						}
					}
				}
				bool flag5 = flag2;
				if (flag5)
				{
					this.goCurrentEffect = null;
				}
				bool flag6 = this.qualityEffectItemArr != null;
				if (flag6)
				{
					for (int j = 0; j < this.qualityEffectItemArr.Length; j++)
					{
						this.qualityEffectItemArr[j].effect.SetActive(false);
					}
				}
				bool isShowTooltip = _param.isShowTooltip;
				if (isShowTooltip)
				{
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(this.goItem, _item.ItemID, new SpriteClickEventHandler(this._OnClickItemIcon));
					this.mXItemToShow = XBagDocument.MakeXItem(_item.ItemID, _isBind);
				}
				else
				{
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.CloseClickShowTooltipEvent(this.goItem);
					this.mXItemToShow = null;
				}
				int num = 0;
				bool flag7 = _item != null;
				if (flag7)
				{
					num = (int)_item.Profession;
				}
				string profName = XSingleton<XProfessionSkillMgr>.singleton.GetProfName(num);
				bool flag8 = _param.playerProf == 0 || _param.playerProf == num || num == 0;
				if (flag8)
				{
					bool flag9 = this.lbProfName != null;
					if (flag9)
					{
						this.lbProfName.SetText(profName);
					}
					bool flag10 = this.goCurrentEffect != null;
					if (flag10)
					{
						this.goCurrentEffect.SetActive(true);
					}
				}
				else
				{
					bool flag11 = this.lbProfName != null;
					if (flag11)
					{
						this.lbProfName.SetText(string.Format(XStringDefineProxy.GetString("EQUIPCREATE_ERROR_FMT"), profName));
					}
					bool flag12 = this.goCurrentEffect != null;
					if (flag12)
					{
						this.goCurrentEffect.SetActive(false);
					}
				}
				bool flag13 = this.lbPartName != null;
				if (flag13)
				{
					EquipList.RowData rowData = null;
					ItemType itemType = (ItemType)_item.ItemType;
					bool flag14 = itemType == ItemType.EQUIP;
					if (flag14)
					{
						rowData = XBagDocument.GetEquipConf(_item.ItemID);
					}
					bool flag15 = rowData != null;
					if (flag15)
					{
						this.lbPartName.SetText(XSingleton<UiUtility>.singleton.GetEquipPartName((EquipPosition)rowData.EquipPos, true));
					}
					else
					{
						this.lbPartName.SetText(XSingleton<UiUtility>.singleton.GetItemTypeStr(itemType));
					}
				}
				bool flag16 = this.goHadGet != null;
				if (flag16)
				{
					ulong num2 = 0UL;
					ItemType itemType2 = (ItemType)_item.ItemType;
					bool flag17 = itemType2 == ItemType.EQUIP || itemType2 == ItemType.ARTIFACT;
					if (flag17)
					{
						num2 = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(_item.ItemID);
					}
					bool flag18 = num2 > 0UL;
					if (flag18)
					{
						this.goHadGet.SetActive(true);
					}
					else
					{
						num2 = (ulong)((long)XSingleton<XGame>.singleton.Doc.XBagDoc.GetBodyItemCountByID(_item.ItemID));
						this.goHadGet.SetActive(num2 > 0UL);
					}
				}
			}
		}

		// Token: 0x060100B7 RID: 65719 RVA: 0x003D23DC File Offset: 0x003D05DC
		private void _OnClickItemIcon(IXUISprite spr)
		{
			bool flag = this.mXItemToShow == null;
			if (flag)
			{
				this.mXItemToShow = XBagDocument.MakeXItem((int)spr.ID, this.bBinding);
			}
			XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(this.mXItemToShow, spr, false, 0U);
		}

		// Token: 0x0400722C RID: 29228
		public IXUILabel lbProfName;

		// Token: 0x0400722D RID: 29229
		public IXUILabel lbLevel;

		// Token: 0x0400722E RID: 29230
		public IXUILabel lbPartName;

		// Token: 0x0400722F RID: 29231
		public GameObject goItem;

		// Token: 0x04007230 RID: 29232
		public GameObject goHadGet;

		// Token: 0x04007231 RID: 29233
		public EquipSetItemBaseView.stQualityEffectItem[] qualityEffectItemArr;

		// Token: 0x04007232 RID: 29234
		public GameObject goCurrentEffect;

		// Token: 0x04007233 RID: 29235
		private XItem mXItemToShow;

		// Token: 0x04007234 RID: 29236
		private bool bBinding = false;

		// Token: 0x02001A14 RID: 6676
		public struct stQualityEffectItem
		{
			// Token: 0x0400823E RID: 33342
			public GameObject effect;

			// Token: 0x0400823F RID: 33343
			public int quality;
		}

		// Token: 0x02001A15 RID: 6677
		public struct stEquipInfoParam
		{
			// Token: 0x04008240 RID: 33344
			public bool isShowTooltip;

			// Token: 0x04008241 RID: 33345
			public int playerProf;
		}
	}
}
