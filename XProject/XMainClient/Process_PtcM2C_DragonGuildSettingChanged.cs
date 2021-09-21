using System;

namespace XMainClient
{
	// Token: 0x0200162D RID: 5677
	internal class Process_PtcM2C_DragonGuildSettingChanged
	{
		// Token: 0x0600EDF2 RID: 60914 RVA: 0x0034910C File Offset: 0x0034730C
		public static void Process(PtcM2C_DragonGuildSettingChanged roPtc)
		{
			XDragonGuildApproveDocument specificDocument = XDocuments.GetSpecificDocument<XDragonGuildApproveDocument>(XDragonGuildApproveDocument.uuID);
			specificDocument.OnSetApprove(new DragonGuildApproveSetting
			{
				autoApprove = (roPtc.Data.needApproval == 0U),
				PPT = roPtc.Data.recuitPPT
			});
		}
	}
}
