using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TooltipButtonOperateEquipUpgrade : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("UPGRADE");
		}

		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		public override bool IsButtonVisible(XItem item)
		{
			bool flag = item == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(item.itemID);
				bool flag2 = equipConf == null;
				result = (!flag2 && equipConf.UpgadeTargetID > 0U);
			}
			return result;
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			EquipUpgradeDocument.Doc.SelectEquip(mainUID);
		}
	}
}
