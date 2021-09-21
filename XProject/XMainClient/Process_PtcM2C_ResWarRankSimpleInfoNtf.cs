using System;

namespace XMainClient
{
	// Token: 0x02001382 RID: 4994
	internal class Process_PtcM2C_ResWarRankSimpleInfoNtf
	{
		// Token: 0x0600E2FF RID: 58111 RVA: 0x00339CE4 File Offset: 0x00337EE4
		public static void Process(PtcM2C_ResWarRankSimpleInfoNtf roPtc)
		{
			XGuildResContentionBuffDocument.Doc.OnGetGuildInfoList(roPtc.Data);
		}
	}
}
