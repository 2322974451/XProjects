using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TooltipButtonOperateEnhance : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("ENHANCE");
		}

		public override bool HasRedPoint(XItem item)
		{
			EquipList.RowData equipConf = XBagDocument.GetEquipConf(item.itemID);
			XEnhanceDocument specificDocument = XDocuments.GetSpecificDocument<XEnhanceDocument>(XEnhanceDocument.uuID);
			return equipConf != null && specificDocument.RedPointEquips.Contains((int)equipConf.EquipPos);
		}

		public override bool IsButtonVisible(XItem item)
		{
			return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Item_Enhance);
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XEnhanceDocument specificDocument = XDocuments.GetSpecificDocument<XEnhanceDocument>(XEnhanceDocument.uuID);
			specificDocument.SelectEquip(mainUID);
		}
	}
}
