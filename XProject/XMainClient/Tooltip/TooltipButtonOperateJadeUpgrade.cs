using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TooltipButtonOperateJadeUpgrade : TooltipButtonOperateBase
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
			return true;
		}

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
