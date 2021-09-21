using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C98 RID: 3224
	internal class TooltipButtonOperateJadeUpgrade : TooltipButtonOperateBase
	{
		// Token: 0x0600B600 RID: 46592 RVA: 0x00240A98 File Offset: 0x0023EC98
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("UPGRADE");
		}

		// Token: 0x0600B601 RID: 46593 RVA: 0x00240AB4 File Offset: 0x0023ECB4
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600B602 RID: 46594 RVA: 0x00240AC8 File Offset: 0x0023ECC8
		public override bool IsButtonVisible(XItem item)
		{
			return true;
		}

		// Token: 0x0600B603 RID: 46595 RVA: 0x00240ADC File Offset: 0x0023ECDC
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XJadeDocument xjadeDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XJadeDocument.uuID) as XJadeDocument;
			XJadeItem jadeItem = xjadeDocument.GetJadeItem(mainUID);
			bool flag = jadeItem != null && XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag)
			{
				JadeTable.RowData byJadeID = xjadeDocument.jadeTable.GetByJadeID((uint)jadeItem.itemID);
				bool flag2 = byJadeID != null;
				if (flag2)
				{
					bool flag3 = (ulong)byJadeID.JadeLevel >= (ulong)((long)xjadeDocument.JadeMosaicLevel.Count);
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("JadeHadMax"), "fece00");
						return;
					}
					bool flag4 = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
					if (flag4)
					{
						return;
					}
					int num = xjadeDocument.JadeLevelToMosaicLevel(byJadeID.JadeLevel + 1U);
					int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
					bool flag5 = level < num;
					if (flag5)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XStringTable>.singleton.GetString("JadeUpgradeNeedLevelTips"), num, byJadeID.JadeLevel + 1U), "fece00");
						return;
					}
				}
			}
			xjadeDocument.TryToCompose(mainUID);
		}
	}
}
