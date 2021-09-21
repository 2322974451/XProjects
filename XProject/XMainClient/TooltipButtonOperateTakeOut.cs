using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E7E RID: 3710
	internal class TooltipButtonOperateTakeOut : TooltipButtonOperateBase
	{
		// Token: 0x0600C67E RID: 50814 RVA: 0x002BF004 File Offset: 0x002BD204
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("TakeOut");
		}

		// Token: 0x0600C67F RID: 50815 RVA: 0x002BF020 File Offset: 0x002BD220
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600C680 RID: 50816 RVA: 0x002BF034 File Offset: 0x002BD234
		public override bool IsButtonVisible(XItem item)
		{
			return XSingleton<TooltipParam>.singleton.bShowTakeOutBtn;
		}

		// Token: 0x0600C681 RID: 50817 RVA: 0x002BF050 File Offset: 0x002BD250
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			ArtifactDeityStoveDocument.Doc.TakeOut(mainUID);
		}
	}
}
