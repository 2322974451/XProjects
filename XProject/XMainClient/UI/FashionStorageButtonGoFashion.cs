using System;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001804 RID: 6148
	internal class FashionStorageButtonGoFashion : TooltipButtonOperateBase
	{
		// Token: 0x0600FEEF RID: 65263 RVA: 0x003C0C14 File Offset: 0x003BEE14
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("FASHION_STORAGE_GO");
		}

		// Token: 0x0600FEF0 RID: 65264 RVA: 0x003C0C30 File Offset: 0x003BEE30
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600FEF1 RID: 65265 RVA: 0x003C0C44 File Offset: 0x003BEE44
		public override bool IsButtonVisible(XItem item)
		{
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			return !specificDocument.InDisplay((uint)item.itemID);
		}

		// Token: 0x0600FEF2 RID: 65266 RVA: 0x003C0C70 File Offset: 0x003BEE70
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess((int)mainUID, null);
		}
	}
}
