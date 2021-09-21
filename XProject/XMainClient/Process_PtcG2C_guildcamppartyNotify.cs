using System;

namespace XMainClient
{
	// Token: 0x020014F3 RID: 5363
	internal class Process_PtcG2C_guildcamppartyNotify
	{
		// Token: 0x0600E8E1 RID: 59617 RVA: 0x00341DE4 File Offset: 0x0033FFE4
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
