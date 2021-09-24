using System;

namespace XMainClient
{

	internal class Process_PtcG2C_GuildSettingChangedNotify
	{

		public static void Process(PtcG2C_GuildSettingChangedNotify roPtc)
		{
			XGuildHallDocument specificDocument = XDocuments.GetSpecificDocument<XGuildHallDocument>(XGuildHallDocument.uuID);
			bool flag = roPtc.Data.annoucement != null;
			if (flag)
			{
				specificDocument.OnAnnounceChanged(roPtc.Data.annoucement);
			}
			specificDocument.OnPortraitChanged(roPtc.Data.Icon);
			XGuildApproveDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildApproveDocument>(XGuildApproveDocument.uuID);
			specificDocument2.OnSetApprove(new GuildApproveSetting
			{
				autoApprove = (roPtc.Data.needApproval == 0),
				PPT = roPtc.Data.RecuitPPT
			});
		}
	}
}
