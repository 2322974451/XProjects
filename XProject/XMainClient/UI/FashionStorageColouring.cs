using System;

namespace XMainClient.UI
{
	// Token: 0x020017FF RID: 6143
	internal class FashionStorageColouring : TooltipButtonOperateBase
	{
		// Token: 0x0600FED6 RID: 65238 RVA: 0x003C0670 File Offset: 0x003BE870
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("HAIR_COULORING");
		}

		// Token: 0x0600FED7 RID: 65239 RVA: 0x003C068C File Offset: 0x003BE88C
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600FED8 RID: 65240 RVA: 0x003C06A0 File Offset: 0x003BE8A0
		public override bool IsButtonVisible(XItem item)
		{
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			bool flag = specificDocument.fashionStorageType > FashionStorageType.OutLook;
			return !flag && XFashionDocument.IsTargetPart(item.itemID, FashionPosition.Hair);
		}

		// Token: 0x0600FED9 RID: 65241 RVA: 0x003C06DC File Offset: 0x003BE8DC
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			specificDocument.SelectHair((uint)mainUID);
		}
	}
}
