using System;

namespace XMainClient
{

	internal class Process_PtcG2C_NoticeHungryDown
	{

		public static void Process(PtcG2C_NoticeHungryDown roPtc)
		{
			XPetDocument specificDocument = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			specificDocument.OnFightPetHungry(roPtc);
		}
	}
}
