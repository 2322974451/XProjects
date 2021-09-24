using System;

namespace XMainClient
{

	internal class Process_PtcG2C_PlatformShareAwardNtf
	{

		public static void Process(PtcG2C_PlatformShareAwardNtf roPtc)
		{
			XAchievementDocument specificDocument = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
			specificDocument.UpdateShareRewardsInfo(roPtc.Data);
		}
	}
}
