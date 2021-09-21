using System;

namespace XMainClient
{
	// Token: 0x0200108F RID: 4239
	internal class Process_PtcG2C_GuildBestCardsNtf
	{
		// Token: 0x0600D6FD RID: 55037 RVA: 0x00327050 File Offset: 0x00325250
		public static void Process(PtcG2C_GuildBestCardsNtf roPtc)
		{
			XGuildJokerDocument specificDocument = XDocuments.GetSpecificDocument<XGuildJokerDocument>(XGuildJokerDocument.uuID);
			specificDocument.SetBestCard(roPtc.Data.bestcards, roPtc.Data.bestrole);
		}
	}
}
