using System;

namespace XMainClient
{
	// Token: 0x020014D4 RID: 5332
	internal class Process_PtcM2C_ArenaStarDataNtf
	{
		// Token: 0x0600E85D RID: 59485 RVA: 0x003413F8 File Offset: 0x0033F5F8
		public static void Process(PtcM2C_ArenaStarDataNtf roPtc)
		{
			XHallFameDocument.Doc.OnGetSupportInfo(roPtc.Data);
		}
	}
}
