using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcM2C_NoticeGuildArenaBeginNew
	{

		public static void Process(PtcM2C_NoticeGuildArenaBeginNew roPtc)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("NoticeGuildArenaBeginNew : ", roPtc.Data.isstart.ToString(), null, null, null, null);
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			specificDocument.bHasAvailableArenaIcon = roPtc.Data.isstart;
		}
	}
}
