using System;

namespace XMainClient
{
	// Token: 0x0200120E RID: 4622
	internal class Process_PtcG2C_NoticeHungryDown
	{
		// Token: 0x0600DD00 RID: 56576 RVA: 0x00331170 File Offset: 0x0032F370
		public static void Process(PtcG2C_NoticeHungryDown roPtc)
		{
			XPetDocument specificDocument = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			specificDocument.OnFightPetHungry(roPtc);
		}
	}
}
