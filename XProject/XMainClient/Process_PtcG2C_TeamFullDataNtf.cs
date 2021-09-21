using System;

namespace XMainClient
{
	// Token: 0x020010DB RID: 4315
	internal class Process_PtcG2C_TeamFullDataNtf
	{
		// Token: 0x0600D824 RID: 55332 RVA: 0x00329178 File Offset: 0x00327378
		public static void Process(PtcG2C_TeamFullDataNtf roPtc)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.OnTeamFullDataNotify(roPtc.Data);
		}
	}
}
