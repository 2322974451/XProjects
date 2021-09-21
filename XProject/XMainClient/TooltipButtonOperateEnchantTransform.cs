using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E88 RID: 3720
	internal class TooltipButtonOperateEnchantTransform : TooltipButtonOperateBase
	{
		// Token: 0x0600C6B8 RID: 50872 RVA: 0x002BFF20 File Offset: 0x002BE120
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("ENCHANT_TRANSFORM");
		}

		// Token: 0x0600C6B9 RID: 50873 RVA: 0x002BFF3C File Offset: 0x002BE13C
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600C6BA RID: 50874 RVA: 0x002BFF50 File Offset: 0x002BE150
		public override bool IsButtonVisible(XItem item)
		{
			XEquipItem xequipItem = item as XEquipItem;
			return xequipItem.enchantInfo.bHasEnchant;
		}

		// Token: 0x0600C6BB RID: 50875 RVA: 0x002BFF74 File Offset: 0x002BE174
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

		// Token: 0x0600C6BC RID: 50876 RVA: 0x002C0020 File Offset: 0x002BE220
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
