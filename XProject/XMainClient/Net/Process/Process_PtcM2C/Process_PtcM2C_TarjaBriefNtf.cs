using System;

namespace XMainClient
{

	internal class Process_PtcM2C_TarjaBriefNtf
	{

		public static void Process(PtcM2C_TarjaBriefNtf roPtc)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetTarja(roPtc.Data.time);
		}
	}
}
