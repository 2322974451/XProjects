using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E7C RID: 3708
	internal class TooltipButtonOperateTakeOff : TooltipButtonOperateBase
	{
		// Token: 0x0600C674 RID: 50804 RVA: 0x002BEEEC File Offset: 0x002BD0EC
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("TAKEOFF");
		}

		// Token: 0x0600C675 RID: 50805 RVA: 0x002BEF08 File Offset: 0x002BD108
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600C676 RID: 50806 RVA: 0x002BEF1C File Offset: 0x002BD11C
		public override bool IsButtonVisible(XItem item)
		{
			bool flag = XSingleton<TooltipParam>.singleton.bShowTakeOutBtn || XSingleton<TooltipParam>.singleton.bShowPutInBtn;
			return !flag;
		}

		// Token: 0x0600C677 RID: 50807 RVA: 0x002BEF50 File Offset: 0x002BD150
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(mainUID);
			bool flag = itemByUID != null;
			if (flag)
			{
				XSingleton<XGame>.singleton.Doc.XBagDoc.UseItem(itemByUID, 1U);
			}
		}
	}
}
