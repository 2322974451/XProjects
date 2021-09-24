using System;

namespace XMainClient
{

	internal class Process_PtcG2C_PvpBattleBeginNtf
	{

		public static void Process(PtcG2C_PvpBattleBeginNtf roPtc)
		{
			XBattleCaptainPVPDocument specificDocument = XDocuments.GetSpecificDocument<XBattleCaptainPVPDocument>(XBattleCaptainPVPDocument.uuID);
			specificDocument.SetBattleBegin(roPtc);
		}
	}
}
