using System;

namespace XMainClient
{
	// Token: 0x02000C9B RID: 3227
	internal class TooltipButtonOperateFashionPutOnSuit : TooltipButtonOperateBase
	{
		// Token: 0x0600B60F RID: 46607 RVA: 0x00240D58 File Offset: 0x0023EF58
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("PUTSUIT");
		}

		// Token: 0x0600B610 RID: 46608 RVA: 0x00240D74 File Offset: 0x0023EF74
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600B611 RID: 46609 RVA: 0x00240D88 File Offset: 0x0023EF88
		public override bool IsButtonVisible(XItem item)
		{
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			bool flag = !specificDocument.ValidPart(item.itemID) || specificDocument.GetFashionSuit(item.itemID) == 0;
			return !flag && specificDocument.ShowSuitAllButton(item.uid);
		}

		// Token: 0x0600B612 RID: 46610 RVA: 0x00240DDC File Offset: 0x0023EFDC
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			ClientFashionData clientFashionData = specificDocument.FindFashion(this.mainItemUID);
			bool flag = clientFashionData != null;
			if (flag)
			{
				specificDocument.EquipFashionSuit(true, (int)clientFashionData.itemID);
			}
		}
	}
}
