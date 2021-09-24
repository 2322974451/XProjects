using System;

namespace XMainClient
{

	internal class Process_PtcM2C_GuildBestCardsNtfMs
	{

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
