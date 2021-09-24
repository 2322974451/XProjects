using System;

namespace XMainClient
{

	internal class Process_PtcG2C_GuildBestCardsNtf
	{

		public static void Process(PtcG2C_GuildBestCardsNtf roPtc)
		{
			XGuildJokerDocument specificDocument = XDocuments.GetSpecificDocument<XGuildJokerDocument>(XGuildJokerDocument.uuID);
			specificDocument.SetBestCard(roPtc.Data.bestcards, roPtc.Data.bestrole);
		}
	}
}
