using System;

namespace XMainClient
{

	internal class Process_PtcG2C_ReachAchieveNtf
	{

		public static void Process(PtcG2C_ReachAchieveNtf roPtc)
		{
			XDesignationDocument specificDocument = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
			specificDocument.OnReachAhieveNtf(roPtc);
		}
	}
}
