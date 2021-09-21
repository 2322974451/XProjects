using System;

namespace XMainClient
{
	// Token: 0x0200138B RID: 5003
	internal class Process_PtcM2C_GuildBuffSimpleItemNtf
	{
		// Token: 0x0600E322 RID: 58146 RVA: 0x00339F84 File Offset: 0x00338184
		public static void Process(PtcM2C_GuildBuffSimpleItemNtf roPtc)
		{
			XGuildResContentionBuffDocument.Doc.OnGetOwnedGuildBuffList(roPtc);
		}
	}
}
