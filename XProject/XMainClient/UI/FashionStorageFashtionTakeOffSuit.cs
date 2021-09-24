using System;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FashionStorageFashtionTakeOffSuit : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("TAKEOFF_FASHIONSUIT");
		}

		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

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
