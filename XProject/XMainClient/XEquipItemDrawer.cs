using System;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XEquipItemDrawer : XItemDrawer
	{

		public override void DrawItem(GameObject go, XItem realItem, bool bForceShowNum = false)
		{
			this._GetUI(go);
			bool flag = realItem == null;
			if (flag)
			{
				this.DrawEmpty();
				this._ClearVariables();
			}
			else
			{
				base._GetItemData(realItem.itemID);
				this._SetupIcon();
				this._SetupAttrIcon(realItem);
				this._SetupName(realItem);
				this._SetupNum(realItem);
				this._SetupNumTop(realItem);
				XEquipItem xequipItem = realItem as XEquipItem;
				base._SetupLeftDownCorner(base._GetBindingState(realItem));
				base._SetupLeftUpCorner(xequipItem.forgeAttrInfo.ForgeAttr.Count > 0, "");
				base._SetupRightDownCorner(false);
				base._SetupRightUpCorner(realItem.Type == ItemType.FRAGMENT);
				base._SetUpProf(false);
				base._SetupMask();
				this._ClearVariables();
			}
		}

		protected override void _SetupName(XItem equip)
		{
			bool flag = this.itemdata == null;
			if (flag)
			{
				base._SetNameUI(null, 1);
			}
			else
			{
				XEquipItem xequipItem = equip as XEquipItem;
				string text = XSingleton<UiUtility>.singleton.ChooseProfString(this.itemdata.ItemName, XItemDrawerMgr.Param.Profession);
				bool flag2 = xequipItem.enhanceInfo.EnhanceLevel > 0U;
				if (flag2)
				{
					base._SetNameUI(string.Format("{0}+{1}", text, xequipItem.enhanceInfo.EnhanceLevel), (int)this.itemdata.ItemQuality);
				}
				else
				{
					base._SetNameUI(text, (int)this.itemdata.ItemQuality);
				}
			}
		}

		protected override void _SetupNum(XItem equip)
		{
			XEquipItem xequipItem = equip as XEquipItem;
			bool flag = xequipItem.enhanceInfo.EnhanceLevel > 0U;
			if (flag)
			{
				base._SetNumUI("[cfff0d]+" + xequipItem.enhanceInfo.EnhanceLevel);
			}
			else
			{
				base._SetNumUI(null);
			}
		}

		protected override void _SetupAttrIcon(XItem equip)
		{
			XEquipItem xequipItem = equip as XEquipItem;
			AttrType attrType = xequipItem.attrType;
			if (attrType != AttrType.Physics)
			{
				if (attrType != AttrType.Magic)
				{
					base._SetAttrIcon(null, null);
				}
				else
				{
					base._SetAttrIcon("f_01", "common/Universal");
				}
			}
			else
			{
				base._SetAttrIcon("r_01", "common/Universal");
			}
		}
	}
}
