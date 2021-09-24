using System;

namespace XMainClient
{

	internal class Process_PtcG2C_CountDownNtf
	{

		public static void Process(PtcG2C_CountDownNtf roPtc)
		{
			XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
			specificDocument.LeaveSceneCountDown(roPtc.Data.time);
		}
	}
}
