using System;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001802 RID: 6146
	internal class FashionStorageFashionTakeOff : TooltipButtonOperateBase
	{
		// Token: 0x0600FEE5 RID: 65253 RVA: 0x003C0A18 File Offset: 0x003BEC18
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("TAKEOFF_FASHION");
		}

		// Token: 0x0600FEE6 RID: 65254 RVA: 0x003C0A34 File Offset: 0x003BEC34
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600FEE7 RID: 65255 RVA: 0x003C0A48 File Offset: 0x003BEC48
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

		// Token: 0x0600FEE8 RID: 65256 RVA: 0x003C0A90 File Offset: 0x003BEC90
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			bool flag = specificDocument.IsOverAll((int)mainUID);
			if (!flag)
			{
				RpcC2G_UseItem rpcC2G_UseItem = new RpcC2G_UseItem();
				rpcC2G_UseItem.oArg.OpType = ItemUseMgr.GetItemUseValue(ItemUse.FashionDisplayOff);
				rpcC2G_UseItem.oArg.itemID = (uint)mainUID;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_UseItem);
			}
		}
	}
}
