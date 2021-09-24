using System;

namespace XMainClient
{

	internal class Process_PtcG2C_RewardChangedNtf
	{

		public static void Process(PtcG2C_RewardChangedNtf roPtc)
		{
			XSystemRewardDocument specificDocument = XDocuments.GetSpecificDocument<XSystemRewardDocument>(XSystemRewardDocument.uuID);
			specificDocument.OnRewardChanged(roPtc.Data);
		}
	}
}
