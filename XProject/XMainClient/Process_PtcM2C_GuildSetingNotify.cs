using System;

namespace XMainClient
{
	// Token: 0x0200129A RID: 4762
	internal class Process_PtcM2C_GuildSetingNotify
	{
		// Token: 0x0600DF4A RID: 57162 RVA: 0x00334590 File Offset: 0x00332790
		public static void Process(PtcM2C_GuildSetingNotify roPtc)
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
