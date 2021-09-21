using System;

namespace XMainClient
{
	// Token: 0x020014A5 RID: 5285
	internal class Process_PtcM2C_PokerTournamentEndReFund
	{
		// Token: 0x0600E79E RID: 59294 RVA: 0x00340440 File Offset: 0x0033E640
		public static void Process(PtcM2C_PokerTournamentEndReFund roPtc)
		{
			XJokerKingDocument specificDocument = XDocuments.GetSpecificDocument<XJokerKingDocument>(XJokerKingDocument.uuID);
			specificDocument.JokerKingGameOver();
		}
	}
}
