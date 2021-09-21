using System;

namespace XMainClient
{
	// Token: 0x020011E3 RID: 4579
	internal class Process_PtcM2C_TeamFullDataM2CNtf
	{
		// Token: 0x0600DC55 RID: 56405 RVA: 0x00330300 File Offset: 0x0032E500
		public static void Process(PtcM2C_TeamFullDataM2CNtf roPtc)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.OnTeamFullDataNotify(roPtc.Data);
		}
	}
}
