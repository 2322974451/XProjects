using System;

namespace XMainClient
{
	// Token: 0x020010DF RID: 4319
	internal class Process_PtcG2C_PetChangeNotfiy
	{
		// Token: 0x0600D834 RID: 55348 RVA: 0x003293AC File Offset: 0x003275AC
		public static void Process(PtcG2C_PetChangeNotfiy roPtc)
		{
			XPetDocument specificDocument = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			specificDocument.OnPetChange(roPtc.Data);
		}
	}
}
