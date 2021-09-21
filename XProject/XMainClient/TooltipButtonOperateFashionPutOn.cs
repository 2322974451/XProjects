using System;

namespace XMainClient
{
	// Token: 0x02000C99 RID: 3225
	internal class TooltipButtonOperateFashionPutOn : TooltipButtonOperateBase
	{
		// Token: 0x0600B605 RID: 46597 RVA: 0x00240C1C File Offset: 0x0023EE1C
		public override bool IsButtonVisible(XItem item)
		{
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			return specificDocument.ValidPart(item.itemID);
		}

		// Token: 0x0600B606 RID: 46598 RVA: 0x00240C48 File Offset: 0x0023EE48
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("PUTON");
		}

		// Token: 0x0600B607 RID: 46599 RVA: 0x00240C64 File Offset: 0x0023EE64
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600B608 RID: 46600 RVA: 0x00240C78 File Offset: 0x0023EE78
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			ClientFashionData clientFashionData = specificDocument.FindFashion(this.mainItemUID);
			bool flag = clientFashionData == null;
			if (!flag)
			{
				specificDocument.EquipFashion(true, this.mainItemUID, (int)clientFashionData.itemID);
			}
		}
	}
}
