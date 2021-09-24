using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TooltipButtonOperateEnhanceTransform : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("ENHANCE_TRANSFORM");
		}

		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		public override bool IsButtonVisible(XItem item)
		{
			XEquipItem xequipItem = item as XEquipItem;
			return xequipItem.enhanceInfo.EnhanceLevel > 0U;
		}

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

		private bool EnhanceTransform(IXUIButton btn)
		{
			XEquipCreateDocument.Doc.ReqEnhanceTransform(this.mainItemUID, this.compareItemUID);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}
	}
}
