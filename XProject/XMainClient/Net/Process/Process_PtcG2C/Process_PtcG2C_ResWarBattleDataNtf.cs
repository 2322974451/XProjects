using System;

namespace XMainClient
{

	internal class Process_PtcG2C_ResWarBattleDataNtf
	{

		public static void Process(PtcG2C_ResWarBattleDataNtf roPtc)
		{
			XGuildMineBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineBattleDocument>(XGuildMineBattleDocument.uuID);
			specificDocument.SetBattleInfo(roPtc);
		}
	}
}
