using System;

namespace XMainClient
{

	internal class Process_PtcG2C_BMRoleSceneSyncNtf
	{

		public static void Process(PtcG2C_BMRoleSceneSyncNtf roPtc)
		{
			XBigMeleeBattleDocument specificDocument = XDocuments.GetSpecificDocument<XBigMeleeBattleDocument>(XBigMeleeBattleDocument.uuID);
			specificDocument.SetBattleData(roPtc);
		}
	}
}
