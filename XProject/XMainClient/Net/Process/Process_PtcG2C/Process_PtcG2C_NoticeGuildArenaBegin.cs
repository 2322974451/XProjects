using System;

namespace XMainClient
{

	internal class Process_PtcG2C_NoticeGuildArenaBegin
	{

		public static void Process(PtcG2C_NoticeGuildArenaBegin roPtc)
		{
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			specificDocument.bHasAvailableArenaIcon = roPtc.Data.isstart;
		}
	}
}
