using System;

namespace XMainClient
{
	// Token: 0x0200107A RID: 4218
	internal class Process_PtcG2C_GuildSettingChangedNotify
	{
		// Token: 0x0600D6A3 RID: 54947 RVA: 0x00326604 File Offset: 0x00324804
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
