using System;

namespace XMainClient
{

	internal class Process_PtcG2C_WorldBossAttrNtf
	{

		public static void Process(PtcG2C_WorldBossAttrNtf roPtc)
		{
			XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
			specificDocument.OnGetAttrCount(roPtc.Data);
		}
	}
}
