using System;

namespace XMainClient
{

	internal class Process_PtcG2C_NoticeGuildBossEnd
	{

		public static void Process(PtcG2C_NoticeGuildBossEnd roPtc)
		{
			XGuildDragonDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
			specificDocument.DragonChallengeResult(roPtc.Data);
		}
	}
}
