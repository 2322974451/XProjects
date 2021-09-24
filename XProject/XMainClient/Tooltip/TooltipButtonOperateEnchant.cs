using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TooltipButtonOperateEnchant : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("ENCHANT");
		}

		public override bool HasRedPoint(XItem item)
		{
			EquipList.RowData equipConf = XBagDocument.GetEquipConf(item.itemID);
			XEnchantDocument specificDocument = XDocuments.GetSpecificDocument<XEnchantDocument>(XEnchantDocument.uuID);
			return equipConf != null && specificDocument.RedPointStates[(int)equipConf.EquipPos];
		}

		public override bool IsButtonVisible(XItem item)
		{
			return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Item_Enchant) && XEnchantDocument.CanEquipEnchant((int)item.itemConf.ReqLevel);
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XEnchantDocument specificDocument = XDocuments.GetSpecificDocument<XEnchantDocument>(XEnchantDocument.uuID);
			specificDocument.SelectEquip(mainUID);
		}
	}
}
