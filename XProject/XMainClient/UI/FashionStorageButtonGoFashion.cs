using System;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FashionStorageButtonGoFashion : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("FASHION_STORAGE_GO");
		}

		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		public override bool IsButtonVisible(XItem item)
		{
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			return !specificDocument.InDisplay((uint)item.itemID);
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess((int)mainUID, null);
		}
	}
}
