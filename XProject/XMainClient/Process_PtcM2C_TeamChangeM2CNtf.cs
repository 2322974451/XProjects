using System;

namespace XMainClient
{
	// Token: 0x020011DD RID: 4573
	internal class Process_PtcM2C_TeamChangeM2CNtf
	{
		// Token: 0x0600DC3E RID: 56382 RVA: 0x00330114 File Offset: 0x0032E314
		public static void Process(PtcM2C_TeamChangeM2CNtf roPtc)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.OnTeamInfoChanged(roPtc.Data);
		}
	}
}
