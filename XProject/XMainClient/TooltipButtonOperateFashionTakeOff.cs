using System;

namespace XMainClient
{
	// Token: 0x02000C9A RID: 3226
	internal class TooltipButtonOperateFashionTakeOff : TooltipButtonOperateBase
	{
		// Token: 0x0600B60A RID: 46602 RVA: 0x00240CC8 File Offset: 0x0023EEC8
		public override bool IsButtonVisible(XItem item)
		{
			return true;
		}

		// Token: 0x0600B60B RID: 46603 RVA: 0x00240CDC File Offset: 0x0023EEDC
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("TAKEOFF");
		}

		// Token: 0x0600B60C RID: 46604 RVA: 0x00240CF8 File Offset: 0x0023EEF8
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600B60D RID: 46605 RVA: 0x00240D0C File Offset: 0x0023EF0C
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			ClientFashionData clientFashionData = specificDocument.FindFashion(this.mainItemUID);
			bool flag = clientFashionData != null;
			if (flag)
			{
				specificDocument.EquipFashion(false, this.mainItemUID, (int)clientFashionData.itemID);
			}
		}
	}
}
