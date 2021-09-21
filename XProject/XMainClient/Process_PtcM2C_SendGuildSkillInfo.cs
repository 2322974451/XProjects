using System;

namespace XMainClient
{
	// Token: 0x02001228 RID: 4648
	internal class Process_PtcM2C_SendGuildSkillInfo
	{
		// Token: 0x0600DD6B RID: 56683 RVA: 0x00331CDC File Offset: 0x0032FEDC
		public static void Process(PtcM2C_SendGuildSkillInfo roPtc)
		{
			XGuildSkillDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSkillDocument>(XGuildSkillDocument.uuID);
			specificDocument.OnUpdateGuildSkillData(roPtc.Data);
		}
	}
}
