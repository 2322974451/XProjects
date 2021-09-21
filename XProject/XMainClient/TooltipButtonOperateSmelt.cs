using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E86 RID: 3718
	internal class TooltipButtonOperateSmelt : TooltipButtonOperateBase
	{
		// Token: 0x0600C6AD RID: 50861 RVA: 0x002BFC88 File Offset: 0x002BDE88
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("SMELT_REPLACE");
		}

		// Token: 0x0600C6AE RID: 50862 RVA: 0x002BFCA4 File Offset: 0x002BDEA4
		public override bool HasRedPoint(XItem item)
		{
			return XSmeltDocument.Doc.IsHadRedDot(item);
		}

		// Token: 0x0600C6AF RID: 50863 RVA: 0x002BFCC4 File Offset: 0x002BDEC4
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

		// Token: 0x0600C6B0 RID: 50864 RVA: 0x002BFD50 File Offset: 0x002BDF50
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XSmeltDocument.Doc.SelectEquip(mainUID);
		}
	}
}
