using System;

namespace XMainClient
{

	internal class Process_PtcG2C_PetChangeNotfiy
	{

		public static void Process(PtcG2C_PetChangeNotfiy roPtc)
		{
			XPetDocument specificDocument = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			specificDocument.OnPetChange(roPtc.Data);
		}
	}
}
