using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E81 RID: 3713
	internal class TooltipButtonOperateEnchant : TooltipButtonOperateBase
	{
		// Token: 0x0600C691 RID: 50833 RVA: 0x002BF544 File Offset: 0x002BD744
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("ENCHANT");
		}

		// Token: 0x0600C692 RID: 50834 RVA: 0x002BF560 File Offset: 0x002BD760
		public override bool HasRedPoint(XItem item)
		{
			EquipList.RowData equipConf = XBagDocument.GetEquipConf(item.itemID);
			XEnchantDocument specificDocument = XDocuments.GetSpecificDocument<XEnchantDocument>(XEnchantDocument.uuID);
			return equipConf != null && specificDocument.RedPointStates[(int)equipConf.EquipPos];
		}

		// Token: 0x0600C693 RID: 50835 RVA: 0x002BF59C File Offset: 0x002BD79C
		public override bool IsButtonVisible(XItem item)
		{
			return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Item_Enchant) && XEnchantDocument.CanEquipEnchant((int)item.itemConf.ReqLevel);
		}

		// Token: 0x0600C694 RID: 50836 RVA: 0x002BF5D0 File Offset: 0x002BD7D0
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XEnchantDocument specificDocument = XDocuments.GetSpecificDocument<XEnchantDocument>(XEnchantDocument.uuID);
			specificDocument.SelectEquip(mainUID);
		}
	}
}
