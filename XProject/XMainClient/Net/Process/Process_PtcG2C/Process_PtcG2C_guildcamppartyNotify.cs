using System;

namespace XMainClient
{

	internal class Process_PtcG2C_guildcamppartyNotify
	{

		public static void Process(PtcG2C_guildcamppartyNotify roPtc)
		{
			XGuildCollectDocument specificDocument = XDocuments.GetSpecificDocument<XGuildCollectDocument>(XGuildCollectDocument.uuID);
			bool flag = roPtc.Data.notify_type == 0U;
			if (flag)
			{
				specificDocument.SetActivityState(false);
			}
			else
			{
				specificDocument.SetTime(roPtc.Data.left_time);
				specificDocument.SetActivityState(true);
				specificDocument.SetLotteryMachineState(roPtc.Data.lottery_list.Count != 0, false);
				specificDocument.SyncNpcList(roPtc.Data.sprite_list);
			}
		}
	}
}
