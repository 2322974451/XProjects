using System;

namespace XMainClient
{

	internal class Process_PtcG2C_OnlineRewardNtf
	{

		public static void Process(PtcG2C_OnlineRewardNtf roPtc)
		{
			XOnlineRewardDocument specificDocument = XDocuments.GetSpecificDocument<XOnlineRewardDocument>(XOnlineRewardDocument.uuID);
			specificDocument.RefreshStatus(roPtc.Data.state, roPtc.Data.timeleft);
		}
	}
}
