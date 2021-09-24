using System;

namespace XMainClient
{

	internal class Process_PtcG2C_BattleWatcherNtf
	{

		public static void Process(PtcG2C_BattleWatcherNtf roPtc)
		{
			XSpectateLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateLevelRewardDocument>(XSpectateLevelRewardDocument.uuID);
			specificDocument.SetData(roPtc.Data);
		}
	}
}
