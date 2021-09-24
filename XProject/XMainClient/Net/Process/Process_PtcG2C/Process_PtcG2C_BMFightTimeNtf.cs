using System;

namespace XMainClient
{

	internal class Process_PtcG2C_BMFightTimeNtf
	{

		public static void Process(PtcG2C_BMFightTimeNtf roPtc)
		{
			XBigMeleeBattleDocument specificDocument = XDocuments.GetSpecificDocument<XBigMeleeBattleDocument>(XBigMeleeBattleDocument.uuID);
			specificDocument.SetBattleTime(roPtc);
		}
	}
}
