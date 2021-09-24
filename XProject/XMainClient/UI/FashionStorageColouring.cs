using System;

namespace XMainClient.UI
{

	internal class FashionStorageColouring : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("HAIR_COULORING");
		}

		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		public override bool IsButtonVisible(XItem item)
		{
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			bool flag = specificDocument.fashionStorageType > FashionStorageType.OutLook;
			return !flag && XFashionDocument.IsTargetPart(item.itemID, FashionPosition.Hair);
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			specificDocument.SelectHair((uint)mainUID);
		}
	}
}
