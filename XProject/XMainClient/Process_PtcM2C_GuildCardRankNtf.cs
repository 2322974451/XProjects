using System;

namespace XMainClient
{
	// Token: 0x020012EC RID: 4844
	internal class Process_PtcM2C_GuildCardRankNtf
	{
		// Token: 0x0600E09C RID: 57500 RVA: 0x003364D4 File Offset: 0x003346D4
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
