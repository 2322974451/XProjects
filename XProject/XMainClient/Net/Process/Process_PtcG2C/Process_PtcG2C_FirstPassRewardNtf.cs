using System;

namespace XMainClient
{

	internal class Process_PtcG2C_FirstPassRewardNtf
	{

		public static void Process(PtcG2C_FirstPassRewardNtf roPtc)
		{
			FirstPassDocument.Doc.RefreshOutRedDot(roPtc.Data.hasCommendReward, roPtc.Data.hasFirstPassReward);
		}
	}
}
