using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class EquipSetItemBaseView
	{

		public void SetFinishItem(XItem item)
		{
			this.mXItemToShow = item;
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(this.goItem, item.itemID, new SpriteClickEventHandler(this._OnClickItemIcon));
		}

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

		public void SetItemInfo(int _itemID, EquipSetItemBaseView.stEquipInfoParam _param, bool _isBind = false)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(_itemID);
			this.SetItemInfo(itemConf, _param, _isBind);
		}

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

		private void _OnClickItemIcon(IXUISprite spr)
		{
			bool flag = this.mXItemToShow == null;
			if (flag)
			{
				this.mXItemToShow = XBagDocument.MakeXItem((int)spr.ID, this.bBinding);
			}
			XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(this.mXItemToShow, spr, false, 0U);
		}

		public IXUILabel lbProfName;

		public IXUILabel lbLevel;

		public IXUILabel lbPartName;

		public GameObject goItem;

		public GameObject goHadGet;

		public EquipSetItemBaseView.stQualityEffectItem[] qualityEffectItemArr;

		public GameObject goCurrentEffect;

		private XItem mXItemToShow;

		private bool bBinding = false;

		public struct stQualityEffectItem
		{

			public GameObject effect;

			public int quality;
		}

		public struct stEquipInfoParam
		{

			public bool isShowTooltip;

			public int playerProf;
		}
	}
}
