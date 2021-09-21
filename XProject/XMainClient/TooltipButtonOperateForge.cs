using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E85 RID: 3717
	internal class TooltipButtonOperateForge : TooltipButtonOperateBase
	{
		// Token: 0x0600C6A8 RID: 50856 RVA: 0x002BFBE4 File Offset: 0x002BDDE4
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("Forge");
		}

		// Token: 0x0600C6A9 RID: 50857 RVA: 0x002BFC00 File Offset: 0x002BDE00
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600C6AA RID: 50858 RVA: 0x002BFC14 File Offset: 0x002BDE14
		public override bool IsButtonVisible(XItem item)
		{
			EquipList.RowData equipConf = XBagDocument.GetEquipConf(item.itemID);
			bool flag = equipConf == null;
			return !flag && (XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Item_Forge) && XForgeDocument.ForgeAttrMgr.IsHadThisEquip(item.itemID)) && equipConf.CanForge == 1;
		}

		// Token: 0x0600C6AB RID: 50859 RVA: 0x002BFC6D File Offset: 0x002BDE6D
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XForgeDocument.Doc.SelectEquip(mainUID);
		}
	}
}
