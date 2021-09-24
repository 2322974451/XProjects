using System;

namespace XMainClient
{

	internal class Process_PtcG2C_MilitaryrankNtf
	{

		public static void Process(PtcG2C_MilitaryrankNtf roPtc)
		{
			XMilitaryRankDocument specificDocument = XDocuments.GetSpecificDocument<XMilitaryRankDocument>(XMilitaryRankDocument.uuID);
			specificDocument.SetMyMilitaryRecord(roPtc.Data);
		}
	}
}
