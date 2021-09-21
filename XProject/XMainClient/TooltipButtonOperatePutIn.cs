using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E7D RID: 3709
	internal class TooltipButtonOperatePutIn : TooltipButtonOperateBase
	{
		// Token: 0x0600C679 RID: 50809 RVA: 0x002BEFA0 File Offset: 0x002BD1A0
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("TAKEIN");
		}

		// Token: 0x0600C67A RID: 50810 RVA: 0x002BEFBC File Offset: 0x002BD1BC
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600C67B RID: 50811 RVA: 0x002BEFD0 File Offset: 0x002BD1D0
		public override bool IsButtonVisible(XItem item)
		{
			return XSingleton<TooltipParam>.singleton.bShowPutInBtn;
		}

		// Token: 0x0600C67C RID: 50812 RVA: 0x002BEFEC File Offset: 0x002BD1EC
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			ArtifactDeityStoveDocument.Doc.Additem(mainUID);
		}
	}
}
