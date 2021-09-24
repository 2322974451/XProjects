using System;
using KKSG;

namespace XMainClient
{

	internal class Process_PtcG2C_SkyCityTimeRes
	{

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
