using System;

namespace XMainClient
{

	internal class Process_PtcM2C_NoticeGuildArenaNextTime
	{

		public static void Process(PtcM2C_NoticeGuildArenaNextTime roPtc)
		{
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			specificDocument.ReceiveGuildArenaNextTime(roPtc.Data);
		}
	}
}
