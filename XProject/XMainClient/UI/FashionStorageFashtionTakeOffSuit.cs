using System;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001803 RID: 6147
	internal class FashionStorageFashtionTakeOffSuit : TooltipButtonOperateBase
	{
		// Token: 0x0600FEEA RID: 65258 RVA: 0x003C0AEC File Offset: 0x003BECEC
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("TAKEOFF_FASHIONSUIT");
		}

		// Token: 0x0600FEEB RID: 65259 RVA: 0x003C0B08 File Offset: 0x003BED08
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600FEEC RID: 65260 RVA: 0x003C0B1C File Offset: 0x003BED1C
		public override bool IsButtonVisible(XItem item)
		{
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			bool flag = specificDocument.fashionStorageType == FashionStorageType.OutLook;
			bool result;
			if (flag)
			{
				XFashionDocument specificDocument2 = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
				bool flag2 = specificDocument2.GetFashionSuit(item.itemID) > 0;
				result = (flag2 || XCharacterEquipDocument.SuitManager.GetSuit(item.itemID, false) != null);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600FEED RID: 65261 RVA: 0x003C0B88 File Offset: 0x003BED88
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			int num = specificDocument.GetFashionSuit((int)mainUID);
			bool flag = num == 0;
			if (flag)
			{
				EquipSuitTable.RowData suit = XCharacterEquipDocument.SuitManager.GetSuit((int)mainUID, false);
				bool flag2 = suit != null;
				if (flag2)
				{
					num = suit.SuitID;
				}
			}
			bool flag3 = num == 0;
			if (!flag3)
			{
				RpcC2G_UseItem rpcC2G_UseItem = new RpcC2G_UseItem();
				rpcC2G_UseItem.oArg.OpType = ItemUseMgr.GetItemUseValue(ItemUse.FashionSuitDisplayOff);
				rpcC2G_UseItem.oArg.suit_id = (uint)num;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_UseItem);
			}
		}
	}
}
