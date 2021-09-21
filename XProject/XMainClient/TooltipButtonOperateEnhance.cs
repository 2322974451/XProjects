using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E80 RID: 3712
	internal class TooltipButtonOperateEnhance : TooltipButtonOperateBase
	{
		// Token: 0x0600C68C RID: 50828 RVA: 0x002BF49C File Offset: 0x002BD69C
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("ENHANCE");
		}

		// Token: 0x0600C68D RID: 50829 RVA: 0x002BF4B8 File Offset: 0x002BD6B8
		public override bool HasRedPoint(XItem item)
		{
			EquipList.RowData equipConf = XBagDocument.GetEquipConf(item.itemID);
			XEnhanceDocument specificDocument = XDocuments.GetSpecificDocument<XEnhanceDocument>(XEnhanceDocument.uuID);
			return equipConf != null && specificDocument.RedPointEquips.Contains((int)equipConf.EquipPos);
		}

		// Token: 0x0600C68E RID: 50830 RVA: 0x002BF4F8 File Offset: 0x002BD6F8
		public override bool IsButtonVisible(XItem item)
		{
			return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Item_Enhance);
		}

		// Token: 0x0600C68F RID: 50831 RVA: 0x002BF518 File Offset: 0x002BD718
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XEnhanceDocument specificDocument = XDocuments.GetSpecificDocument<XEnhanceDocument>(XEnhanceDocument.uuID);
			specificDocument.SelectEquip(mainUID);
		}
	}
}
