using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C9E RID: 3230
	internal class TooltipButtonOperateEquipFusion : TooltipButtonOperateBase
	{
		// Token: 0x0600B61F RID: 46623 RVA: 0x0024111C File Offset: 0x0023F31C
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("EquipFusion");
		}

		// Token: 0x0600B620 RID: 46624 RVA: 0x00241138 File Offset: 0x0023F338
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600B621 RID: 46625 RVA: 0x0024114C File Offset: 0x0023F34C
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

		// Token: 0x0600B622 RID: 46626 RVA: 0x002411A7 File Offset: 0x0023F3A7
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			EquipFusionDocument.Doc.SelectEquip(mainUID);
		}
	}
}
