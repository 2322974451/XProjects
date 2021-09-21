using System;

namespace XMainClient
{
	// Token: 0x02000DD3 RID: 3539
	internal class XCommandPureOverlay : XBaseCommand
	{
		// Token: 0x0600C0BD RID: 49341 RVA: 0x0028D2BC File Offset: 0x0028B4BC
		public override bool Execute()
		{
			base.SetOverlay();
			base.publicModule();
			return true;
		}

		// Token: 0x0600C0BE RID: 49342 RVA: 0x0028D2DD File Offset: 0x0028B4DD
		public override void Stop()
		{
			base.DestroyOverlay();
		}
	}
}
