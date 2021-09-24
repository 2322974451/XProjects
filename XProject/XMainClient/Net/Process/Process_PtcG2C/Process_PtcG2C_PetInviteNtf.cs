using System;

namespace XMainClient
{

	internal class Process_PtcG2C_PetInviteNtf
	{

		public static void Process(PtcG2C_PetInviteNtf roPtc)
		{
			XPetDocument specificDocument = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			specificDocument.OnPetInviteNtfPtc(roPtc.Data);
		}
	}
}
