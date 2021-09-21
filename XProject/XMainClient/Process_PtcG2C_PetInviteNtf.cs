using System;

namespace XMainClient
{
	// Token: 0x0200154E RID: 5454
	internal class Process_PtcG2C_PetInviteNtf
	{
		// Token: 0x0600EA53 RID: 59987 RVA: 0x00344094 File Offset: 0x00342294
		public static void Process(PtcG2C_PetInviteNtf roPtc)
		{
			XPetDocument specificDocument = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			specificDocument.OnPetInviteNtfPtc(roPtc.Data);
		}
	}
}
