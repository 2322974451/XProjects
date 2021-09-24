using System;

namespace XMainClient
{

	internal class Process_PtcG2C_TeamFullDataNtf
	{

		public static void Process(PtcG2C_TeamFullDataNtf roPtc)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.OnTeamFullDataNotify(roPtc.Data);
		}
	}
}
