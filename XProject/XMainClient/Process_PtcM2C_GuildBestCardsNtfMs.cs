using System;

namespace XMainClient
{
	// Token: 0x020012AE RID: 4782
	internal class Process_PtcM2C_GuildBestCardsNtfMs
	{
		// Token: 0x0600DF98 RID: 57240 RVA: 0x00334D2C File Offset: 0x00332F2C
		public static void Process(PtcM2C_GuildBestCardsNtfMs roPtc)
		{
			bool flag = roPtc.Data.match_type == 1U;
			if (flag)
			{
				XJokerKingDocument specificDocument = XDocuments.GetSpecificDocument<XJokerKingDocument>(XJokerKingDocument.uuID);
				specificDocument.SetBestJocker(roPtc.Data.bestcards, roPtc.Data.bestrole);
			}
			else
			{
				bool flag2 = roPtc.Data.type == 0U;
				if (flag2)
				{
					XGuildJokerDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildJokerDocument>(XGuildJokerDocument.uuID);
					specificDocument2.SetBestCard(roPtc.Data.bestcards, roPtc.Data.bestrole);
				}
				else
				{
					bool flag3 = roPtc.Data.type == 1U;
					if (flag3)
					{
						XGuildJockerMatchDocument specificDocument3 = XDocuments.GetSpecificDocument<XGuildJockerMatchDocument>(XGuildJockerMatchDocument.uuID);
						specificDocument3.SetBestJocker(roPtc.Data.bestcards, roPtc.Data.bestrole);
					}
				}
			}
		}
	}
}
