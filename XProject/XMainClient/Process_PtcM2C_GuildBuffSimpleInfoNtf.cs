using System;

namespace XMainClient
{
	// Token: 0x02001384 RID: 4996
	internal class Process_PtcM2C_GuildBuffSimpleInfoNtf
	{
		// Token: 0x0600E306 RID: 58118 RVA: 0x00339D50 File Offset: 0x00337F50
		public static void Process(PtcM2C_GuildBuffSimpleInfoNtf roPtc)
		{
			XGuildResContentionBuffDocument.Doc.OnGetGuildBuffList(roPtc.Data.buff);
		}
	}
}
