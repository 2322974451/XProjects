using System;

namespace XMainClient
{
	// Token: 0x02000C9C RID: 3228
	internal class TooltipButtonOperateFashionTakeOffSuit : TooltipButtonOperateBase
	{
		// Token: 0x0600B614 RID: 46612 RVA: 0x00240E24 File Offset: 0x0023F024
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("TAKEOFFALL");
		}

		// Token: 0x0600B615 RID: 46613 RVA: 0x00240E40 File Offset: 0x0023F040
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600B616 RID: 46614 RVA: 0x00240E54 File Offset: 0x0023F054
		public override bool IsButtonVisible(XItem item)
		{
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			bool flag = specificDocument.GetFashionSuit(item.itemID) == 0;
			return !flag && specificDocument.ShowSuitAllButton(item.uid);
		}

		// Token: 0x0600B617 RID: 46615 RVA: 0x00240E94 File Offset: 0x0023F094
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			ClientFashionData clientFashionData = specificDocument.FindFashion(this.mainItemUID);
			bool flag = clientFashionData == null;
			if (!flag)
			{
				specificDocument.EquipFashionSuit(false, (int)clientFashionData.itemID);
			}
		}
	}
}
