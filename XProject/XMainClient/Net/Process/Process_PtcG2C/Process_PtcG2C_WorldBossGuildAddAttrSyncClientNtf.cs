using System;

namespace XMainClient
{

	internal class Process_PtcG2C_WorldBossGuildAddAttrSyncClientNtf
	{

		public static void Process(PtcG2C_WorldBossGuildAddAttrSyncClientNtf roPtc)
		{
			XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
			specificDocument.ReceiveGuildAttAttrSync(roPtc.Data);
		}
	}
}
