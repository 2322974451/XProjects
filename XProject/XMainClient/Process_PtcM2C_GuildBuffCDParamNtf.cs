using System;

namespace XMainClient
{
	// Token: 0x020013C1 RID: 5057
	internal class Process_PtcM2C_GuildBuffCDParamNtf
	{
		// Token: 0x0600E401 RID: 58369 RVA: 0x0033B1C8 File Offset: 0x003393C8
		public static void Process(PtcM2C_GuildBuffCDParamNtf roPtc)
		{
			XGuildResContentionBuffDocument.Doc.OnGetGuildBuffCD(roPtc.Data);
		}
	}
}
