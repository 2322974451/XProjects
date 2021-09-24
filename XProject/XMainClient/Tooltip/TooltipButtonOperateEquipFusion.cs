using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TooltipButtonOperateEquipFusion : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("EquipFusion");
		}

		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		public override bool IsButtonVisible(XItem item)
		{
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_EquipFusion);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = item == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					EquipList.RowData equipConf = XBagDocument.GetEquipConf(item.itemID);
					bool flag3 = equipConf == null;
					result = (!flag3 && equipConf.FuseCanBreakNum > 0);
				}
			}
			return result;
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			EquipFusionDocument.Doc.SelectEquip(mainUID);
		}
	}
}
