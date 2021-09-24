using System;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FashionStorageFashionTakeOff : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("TAKEOFF_FASHION");
		}

		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

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
