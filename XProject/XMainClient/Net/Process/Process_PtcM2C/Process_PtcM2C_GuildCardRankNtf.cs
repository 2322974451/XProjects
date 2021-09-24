using System;

namespace XMainClient
{

	internal class Process_PtcM2C_GuildCardRankNtf
	{

		public static void Process(PtcM2C_GuildCardRankNtf roPtc)
		{
			bool flag = roPtc.Data.type == 0U || roPtc.Data.type == 1U;
			if (flag)
			{
				XGuildJokerDocument specificDocument = XDocuments.GetSpecificDocument<XGuildJokerDocument>(XGuildJokerDocument.uuID);
				specificDocument.ReceiveJockerRank(roPtc.Data.name, roPtc.Data.point);
			}
			else
			{
				bool flag2 = roPtc.Data.type == 2U;
				if (flag2)
				{
					XGuildJockerMatchDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildJockerMatchDocument>(XGuildJockerMatchDocument.uuID);
					specificDocument2.ReceiveJokerRank(roPtc.Data.name, roPtc.Data.point);
				}
				else
				{
					bool flag3 = roPtc.Data.type == 3U;
					if (flag3)
					{
						XJokerKingDocument specificDocument3 = XDocuments.GetSpecificDocument<XJokerKingDocument>(XJokerKingDocument.uuID);
						specificDocument3.ReceiveJokerRank(roPtc.Data.name, roPtc.Data.point);
					}
				}
			}
		}
	}
}
