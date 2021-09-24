using System;

namespace XMainClient
{

	internal class Process_PtcG2C_WorldBossStateNtf
	{

		public static void Process(PtcG2C_WorldBossStateNtf roPtc)
		{
			XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
			specificDocument.OnWorldBossStateNtf(roPtc.Data);
		}
	}
}
