using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TooltipButtonOperateForge : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("Forge");
		}

		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		public override bool IsButtonVisible(XItem item)
		{
			EquipList.RowData equipConf = XBagDocument.GetEquipConf(item.itemID);
			bool flag = equipConf == null;
			return !flag && (XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Item_Forge) && XForgeDocument.ForgeAttrMgr.IsHadThisEquip(item.itemID)) && equipConf.CanForge == 1;
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XForgeDocument.Doc.SelectEquip(mainUID);
		}
	}
}
