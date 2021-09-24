using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TooltipButtonOperateEnchantTransform : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("ENCHANT_TRANSFORM");
		}

		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		public override bool IsButtonVisible(XItem item)
		{
			XEquipItem xequipItem = item as XEquipItem;
			return xequipItem.enchantInfo.bHasEnchant;
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(mainUID);
			bool flag = itemByUID != null;
			if (flag)
			{
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(itemByUID.itemID);
				bool flag2 = equipConf != null;
				if (flag2)
				{
					bool flag3 = this.compareItemUID == 0UL;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EnchantTrasform"), "fece00");
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("EnchantTransformConfirm"), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(this._EnchantTransform));
					}
				}
			}
		}

		private bool _EnchantTransform(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			RpcC2G_EnchantTransfer rpcC2G_EnchantTransfer = new RpcC2G_EnchantTransfer();
			rpcC2G_EnchantTransfer.oArg.destuid = this.compareItemUID;
			rpcC2G_EnchantTransfer.oArg.originuid = this.mainItemUID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_EnchantTransfer);
			return true;
		}
	}
}
