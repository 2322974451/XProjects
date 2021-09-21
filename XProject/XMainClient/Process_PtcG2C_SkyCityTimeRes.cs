using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020012D1 RID: 4817
	internal class Process_PtcG2C_SkyCityTimeRes
	{
		// Token: 0x0600E026 RID: 57382 RVA: 0x00335990 File Offset: 0x00333B90
		public static void Process(PtcG2C_SkyCityTimeRes roPtc)
		{
			bool flag = roPtc.Data.type == SkyCityTimeType.Waiting;
			if (flag)
			{
				XSkyArenaEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XSkyArenaEntranceDocument>(XSkyArenaEntranceDocument.uuID);
				specificDocument.SetTime(roPtc.Data.time);
			}
		}
	}
}
