using System;

namespace XMainClient
{

	internal class Process_PtcG2C_NotifyWatchIconNum2Client
	{

		public static void Process(PtcG2C_NotifyWatchIconNum2Client roPtc)
		{
			XSpectateDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID);
			specificDocument.SetLiveCount(roPtc.Data.num);
		}
	}
}
