using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C9F RID: 3231
	internal class TooltipButtonOperateEquipUpgrade : TooltipButtonOperateBase
	{
		// Token: 0x0600B624 RID: 46628 RVA: 0x002411C0 File Offset: 0x0023F3C0
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("UPGRADE");
		}

		// Token: 0x0600B625 RID: 46629 RVA: 0x002411DC File Offset: 0x0023F3DC
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600B626 RID: 46630 RVA: 0x002411F0 File Offset: 0x0023F3F0
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

		// Token: 0x0600B627 RID: 46631 RVA: 0x0024122F File Offset: 0x0023F42F
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			EquipUpgradeDocument.Doc.SelectEquip(mainUID);
		}
	}
}
