using System;

namespace XMainClient
{

	internal class Process_PtcG2C_NextDayRewardNtf
	{

		public static void Process(PtcG2C_NextDayRewardNtf roPtc)
		{
			XNextDayRewardDocument specificDocument = XDocuments.GetSpecificDocument<XNextDayRewardDocument>(XNextDayRewardDocument.uuID);
			specificDocument.RefreshStatus(roPtc.Data.state, roPtc.Data.timeleft);
		}
	}
}
