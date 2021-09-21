using System;

namespace XMainClient
{
	// Token: 0x020013A9 RID: 5033
	internal class Process_PtcM2C_ResWarMineDataNtf
	{
		// Token: 0x0600E3A0 RID: 58272 RVA: 0x0033A964 File Offset: 0x00338B64
		public static void Process(PtcM2C_ResWarMineDataNtf roPtc)
		{
			XGuildResContentionBuffDocument.Doc.OnGetGuildResUpdate(roPtc.Data);
		}
	}
}
