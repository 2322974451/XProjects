using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TooltipButtonOperateSmelt : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("SMELT_REPLACE");
		}

		public override bool HasRedPoint(XItem item)
		{
			return XSmeltDocument.Doc.IsHadRedDot(item);
		}

		public override bool IsButtonVisible(XItem item)
		{
			EquipList.RowData rowData = null;
			XEquipItem xequipItem = item as XEquipItem;
			bool flag = item != null;
			if (flag)
			{
				rowData = XBagDocument.GetEquipConf(item.itemID);
			}
			return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Item_Smelting) && (int)item.itemConf.ReqLevel >= XSingleton<XGlobalConfig>.singleton.GetInt("SmeltEquipMinLevel") && xequipItem.randAttrInfo.RandAttr.Count + xequipItem.forgeAttrInfo.ForgeAttr.Count > 0 && rowData != null && rowData.IsCanSmelt;
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XSmeltDocument.Doc.SelectEquip(mainUID);
		}
	}
}
