using System;

namespace XMainClient
{

	internal class Process_PtcM2C_DragonGuildSettingChanged
	{

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
