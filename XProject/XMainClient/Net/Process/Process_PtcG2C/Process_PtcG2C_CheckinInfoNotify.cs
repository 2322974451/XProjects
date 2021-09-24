using System;

namespace XMainClient
{

	internal class Process_PtcG2C_CheckinInfoNotify
	{

		public static void Process(PtcG2C_CheckinInfoNotify roPtc)
		{
			XLoginRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLoginRewardDocument>(XLoginRewardDocument.uuID);
			specificDocument.OnCheckinInfoNotify(roPtc.Data);
		}
	}
}
