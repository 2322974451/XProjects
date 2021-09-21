using System;

namespace XMainClient
{
	// Token: 0x0200140B RID: 5131
	internal class Process_PtcG2C_InvFightBefEnterSceneNtf
	{
		// Token: 0x0600E533 RID: 58675 RVA: 0x0033CA2C File Offset: 0x0033AC2C
		public static void Process(PtcG2C_InvFightBefEnterSceneNtf roPtc)
		{
			XPKInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XPKInvitationDocument>(XPKInvitationDocument.uuID);
			specificDocument.EnterFightScene(roPtc);
		}
	}
}
