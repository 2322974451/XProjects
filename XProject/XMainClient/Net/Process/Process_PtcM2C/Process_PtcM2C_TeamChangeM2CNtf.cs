using System;

namespace XMainClient
{

	internal class Process_PtcM2C_TeamChangeM2CNtf
	{

		public static void Process(PtcM2C_TeamChangeM2CNtf roPtc)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.OnTeamInfoChanged(roPtc.Data);
		}
	}
}
