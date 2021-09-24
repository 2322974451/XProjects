using System;

namespace XMainClient
{

	internal class Process_PtcG2C_BigMeleeReliveNtf
	{

		public static void Process(PtcG2C_BigMeleeReliveNtf roPtc)
		{
			XBigMeleeBattleDocument specificDocument = XDocuments.GetSpecificDocument<XBigMeleeBattleDocument>(XBigMeleeBattleDocument.uuID);
			specificDocument.SetReviveTime(roPtc);
		}
	}
}
