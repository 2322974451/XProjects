using System;

namespace XMainClient
{

	internal class Process_PtcM2C_PokerTournamentEndReFund
	{

		public static void Process(PtcM2C_PokerTournamentEndReFund roPtc)
		{
			XJokerKingDocument specificDocument = XDocuments.GetSpecificDocument<XJokerKingDocument>(XJokerKingDocument.uuID);
			specificDocument.JokerKingGameOver();
		}
	}
}
