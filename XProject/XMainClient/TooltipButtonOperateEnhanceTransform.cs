using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E87 RID: 3719
	internal class TooltipButtonOperateEnhanceTransform : TooltipButtonOperateBase
	{
		// Token: 0x0600C6B2 RID: 50866 RVA: 0x002BFD68 File Offset: 0x002BDF68
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("ENHANCE_TRANSFORM");
		}

		// Token: 0x0600C6B3 RID: 50867 RVA: 0x002BFD84 File Offset: 0x002BDF84
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600C6B4 RID: 50868 RVA: 0x002BFD98 File Offset: 0x002BDF98
		public override bool IsButtonVisible(XItem item)
		{
			XEquipItem xequipItem = item as XEquipItem;
			return xequipItem.enhanceInfo.EnhanceLevel > 0U;
		}

		// Token: 0x0600C6B5 RID: 50869 RVA: 0x002BFDC0 File Offset: 0x002BDFC0
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this.mainItemUID);
			bool flag = itemByUID != null;
			if (flag)
			{
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(itemByUID.itemID);
				bool flag2 = equipConf != null;
				if (flag2)
				{
					XItem xitem = XBagDocument.BagDoc.EquipBag[(int)equipConf.EquipPos];
					bool flag3 = xitem == null || this.compareItemUID != xitem.uid;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EnhanceTrasform"), "fece00");
					}
					else
					{
						EquipList.RowData equipConf2 = XBagDocument.GetEquipConf(xitem.itemID);
						string text = "";
						ItemList.RowData itemConf = XBagDocument.GetItemConf(itemByUID.itemID);
						bool flag4 = itemConf != null;
						if (flag4)
						{
							text = itemConf.ItemName[0];
						}
						text = string.Format(XStringDefineProxy.GetString("EnhanceTrasformTips"), text);
						XSingleton<UiUtility>.singleton.ShowModalDialog(text, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.EnhanceTransform));
					}
				}
			}
		}

		// Token: 0x0600C6B6 RID: 50870 RVA: 0x002BFEE8 File Offset: 0x002BE0E8
		private bool EnhanceTransform(IXUIButton btn)
		{
			XEquipCreateDocument.Doc.ReqEnhanceTransform(this.mainItemUID, this.compareItemUID);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}
	}
}
