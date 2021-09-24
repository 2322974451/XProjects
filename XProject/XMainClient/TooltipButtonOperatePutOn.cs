using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TooltipButtonOperatePutOn : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("PUTON");
		}

		public override bool HasRedPoint(XItem item)
		{
			XCharacterEquipDocument specificDocument = XDocuments.GetSpecificDocument<XCharacterEquipDocument>(XCharacterEquipDocument.uuID);
			EquipCompare mix = specificDocument.IsEquipMorePowerful(item.uid);
			EquipCompare final = XCharacterEquipDocument.GetFinal(mix);
			return final == EquipCompare.EC_MORE_POWERFUL;
		}

		public override bool IsButtonVisible(XItem item)
		{
			return true;
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this.mainItemUID);
			bool flag = itemByUID == null || itemByUID.itemConf == null;
			if (!flag)
			{
				ItemList.RowData itemConf = itemByUID.itemConf;
				bool flag2 = !itemByUID.bBinding && itemConf.ItemQuality >= 3;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("BINDING_CONFIRM"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._Equip));
				}
				else
				{
					bool flag3 = itemByUID.Type == ItemType.EQUIP;
					if (flag3)
					{
						EquipFusionDocument.IsEquipDown = true;
					}
					XSingleton<XGame>.singleton.Doc.XBagDoc.UseItem(itemByUID, 0U);
				}
			}
		}

		private bool _Equip(IXUIButton btn)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this.mainItemUID);
			bool flag = itemByUID != null;
			if (flag)
			{
				bool flag2 = itemByUID.Type == ItemType.EQUIP;
				if (flag2)
				{
					EquipFusionDocument.IsEquipDown = true;
				}
				XSingleton<XGame>.singleton.Doc.XBagDoc.UseItem(itemByUID, 0U);
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		private bool _Equip0(IXUIButton btn)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this.mainItemUID);
			bool flag = itemByUID != null;
			if (flag)
			{
				XSingleton<XGame>.singleton.Doc.XBagDoc.UseItem(itemByUID, 0U, 0U);
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		private bool _Equip1(IXUIButton btn)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this.mainItemUID);
			bool flag = itemByUID != null;
			if (flag)
			{
				XSingleton<XGame>.singleton.Doc.XBagDoc.UseItem(itemByUID, 0U, 1U);
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		private bool IsNeedJadeTip(XEquipItem equip, XEquipItem equipedEquip)
		{
			bool flag = equip == null || equip.itemID == 0 || equipedEquip == null || equipedEquip.itemID == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int num = 0;
				foreach (uint num2 in equip.jadeInfo.AllSlots())
				{
					XJadeItem xjadeItem = equip.jadeInfo.jades[num];
					bool flag2 = xjadeItem != null;
					if (flag2)
					{
						return false;
					}
					num++;
				}
				XJadeDocument specificDocument = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID);
				num = 0;
				foreach (uint num3 in equipedEquip.jadeInfo.AllSlots())
				{
					XJadeItem xjadeItem = equipedEquip.jadeInfo.jades[num];
					bool flag3 = xjadeItem != null;
					if (flag3)
					{
						JadeTable.RowData byJadeID = specificDocument.jadeTable.GetByJadeID((uint)xjadeItem.itemID);
						bool flag4 = byJadeID == null || XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
						if (flag4)
						{
							continue;
						}
						int num4 = specificDocument.JadeLevelToMosaicLevel(byJadeID.JadeLevel);
						bool flag5 = (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= (ulong)((long)num4);
						if (flag5)
						{
							foreach (uint num5 in equip.jadeInfo.AllSlots())
							{
								bool flag6 = num5 == num3;
								if (flag6)
								{
									return true;
								}
							}
						}
					}
					num++;
				}
				result = false;
			}
			return result;
		}
	}
}
