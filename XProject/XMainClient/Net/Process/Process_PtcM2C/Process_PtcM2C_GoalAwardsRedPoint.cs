using System;

namespace XMainClient
{

	internal class Process_PtcM2C_GoalAwardsRedPoint
	{

		public static void Process(PtcM2C_GoalAwardsRedPoint roPtc)
		{
			XTargetRewardDocument specificDocument = XDocuments.GetSpecificDocument<XTargetRewardDocument>(XTargetRewardDocument.uuID);
			specificDocument.SetRedPointList(roPtc.Data.typelist);
		}
	}
}
