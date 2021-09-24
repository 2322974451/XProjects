using System;

namespace XMainClient
{

	internal class Process_PtcG2C_PvpBattleEndNtf
	{

		public static void Process(PtcG2C_PvpBattleEndNtf roPtc)
		{
			XBattleCaptainPVPDocument specificDocument = XDocuments.GetSpecificDocument<XBattleCaptainPVPDocument>(XBattleCaptainPVPDocument.uuID);
			specificDocument.SetBattleEnd(roPtc);
		}
	}
}
