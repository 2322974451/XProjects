using System;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001800 RID: 6144
	internal class FashionStorageFashionPutOn : TooltipButtonOperateBase
	{
		// Token: 0x0600FEDB RID: 65243 RVA: 0x003C0700 File Offset: 0x003BE900
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("PUT_FASHION");
		}

		// Token: 0x0600FEDC RID: 65244 RVA: 0x003C071C File Offset: 0x003BE91C
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600FEDD RID: 65245 RVA: 0x003C0730 File Offset: 0x003BE930
		public override bool IsButtonVisible(XItem item)
		{
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			bool flag = specificDocument.fashionStorageType > FashionStorageType.OutLook;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XFashionDocument specificDocument2 = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
				result = !specificDocument2.IsOverAll(item.itemID);
			}
			return result;
		}

		// Token: 0x0600FEDE RID: 65246 RVA: 0x003C0778 File Offset: 0x003BE978
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			bool flag = specificDocument.IsOverAll((int)mainUID);
			if (!flag)
			{
				XFashionStorageDocument specificDocument2 = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
				bool flag2 = XFashionDocument.IsTargetPart((int)mainUID, FashionPosition.FASHION_START);
				if (flag2)
				{
					specificDocument2.CheckMutuexHeadgear((int)mainUID);
				}
				else
				{
					bool flag3 = XFashionDocument.IsTargetPart((int)mainUID, FashionPosition.Hair);
					if (flag3)
					{
						specificDocument2.CheckMutuexHair((int)mainUID);
					}
				}
				RpcC2G_UseItem rpcC2G_UseItem = new RpcC2G_UseItem();
				rpcC2G_UseItem.oArg.OpType = ItemUseMgr.GetItemUseValue(ItemUse.FashionDisplayWear);
				rpcC2G_UseItem.oArg.itemID = (uint)mainUID;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_UseItem);
			}
		}
	}
}
