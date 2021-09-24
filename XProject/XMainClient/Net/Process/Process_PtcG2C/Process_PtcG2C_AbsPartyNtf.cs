using System;

namespace XMainClient
{

	internal class Process_PtcG2C_AbsPartyNtf
	{

		public static void Process(PtcG2C_AbsPartyNtf roPtc)
		{
			XAbyssPartyDocument specificDocument = XDocuments.GetSpecificDocument<XAbyssPartyDocument>(XAbyssPartyDocument.uuID);
			specificDocument.SetAbyssIndex(roPtc.Data.aby);
		}
	}
}
