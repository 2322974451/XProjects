using System;

namespace XMainClient
{

	internal class Process_PtcG2C_GuildBossTimeOut
	{

		public static void Process(PtcG2C_GuildBossTimeOut roPtc)
		{
			XGuildDragonDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
			specificDocument.GuildBossTimeOut();
		}
	}
}
