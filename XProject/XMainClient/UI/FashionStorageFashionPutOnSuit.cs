using System;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001801 RID: 6145
	internal class FashionStorageFashionPutOnSuit : TooltipButtonOperateBase
	{
		// Token: 0x0600FEE0 RID: 65248 RVA: 0x003C0810 File Offset: 0x003BEA10
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("PUT_FASHIONSUIT");
		}

		// Token: 0x0600FEE1 RID: 65249 RVA: 0x003C082C File Offset: 0x003BEA2C
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600FEE2 RID: 65250 RVA: 0x003C0840 File Offset: 0x003BEA40
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

		// Token: 0x0600FEE3 RID: 65251 RVA: 0x003C08AC File Offset: 0x003BEAAC
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			XFashionStorageDocument specificDocument2 = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			int num = specificDocument.GetFashionSuit((int)mainUID);
			bool flag = num == 0;
			if (flag)
			{
				EquipSuitTable.RowData suit = XCharacterEquipDocument.SuitManager.GetSuit((int)mainUID, false);
				bool flag2 = suit != null;
				if (flag2)
				{
					bool flag3 = suit.EquipID != null;
					if (flag3)
					{
						for (int i = 0; i < suit.EquipID.Length; i++)
						{
							int num2 = suit.EquipID[i];
							bool flag4 = XFashionDocument.IsTargetPart(num2, FashionPosition.FASHION_START);
							if (flag4)
							{
								specificDocument2.CheckMutuexHeadgear(num2);
								break;
							}
						}
					}
					num = suit.SuitID;
				}
			}
			else
			{
				FashionSuitTable.RowData suitData = specificDocument.GetSuitData(num);
				bool flag5 = suitData != null && suitData.FashionID != null;
				if (flag5)
				{
					int j = 0;
					int num3 = suitData.FashionID.Length;
					while (j < num3)
					{
						bool flag6 = XFashionDocument.IsTargetPart((int)suitData.FashionID[j], FashionPosition.FASHION_START);
						if (flag6)
						{
							specificDocument2.CheckMutuexHeadgear((int)suitData.FashionID[j]);
							break;
						}
						j++;
					}
				}
			}
			bool flag7 = num == 0;
			if (!flag7)
			{
				RpcC2G_UseItem rpcC2G_UseItem = new RpcC2G_UseItem();
				rpcC2G_UseItem.oArg.OpType = ItemUseMgr.GetItemUseValue(ItemUse.FashionSuitDisplayWear);
				rpcC2G_UseItem.oArg.suit_id = (uint)num;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_UseItem);
			}
		}
	}
}
