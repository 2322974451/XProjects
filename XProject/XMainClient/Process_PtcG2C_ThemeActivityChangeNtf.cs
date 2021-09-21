using System;

namespace XMainClient
{
	// Token: 0x020015D0 RID: 5584
	internal class Process_PtcG2C_ThemeActivityChangeNtf
	{
		// Token: 0x0600EC6A RID: 60522 RVA: 0x00347120 File Offset: 0x00345320
		public static void Process(PtcG2C_ThemeActivityChangeNtf roPtc)
		{
			XThemeActivityDocument.Doc.SetActivityChange(roPtc);
		}
	}
}
