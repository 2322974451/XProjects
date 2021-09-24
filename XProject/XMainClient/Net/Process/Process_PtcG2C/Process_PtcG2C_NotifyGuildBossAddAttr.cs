using System;

namespace XMainClient
{

	internal class Process_PtcG2C_NotifyGuildBossAddAttr
	{

		public static void Process(PtcG2C_NotifyGuildBossAddAttr roPtc)
		{
			XGuildDragonDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
			specificDocument.OnNotifyEncourage(roPtc.Data.count);
		}
	}
}
