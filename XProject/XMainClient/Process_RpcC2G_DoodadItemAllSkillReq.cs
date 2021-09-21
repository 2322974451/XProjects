using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001651 RID: 5713
	internal class Process_RpcC2G_DoodadItemAllSkillReq
	{
		// Token: 0x0600EE8F RID: 61071 RVA: 0x00349F20 File Offset: 0x00348120
		public static void OnReply(EmptyData oArg, DoodadItemAllSkill oRes)
		{
			bool flag = XRaceDocument.Doc.RaceHandler != null;
			if (flag)
			{
				XRaceDocument.Doc.RaceHandler.RefreshDoodad(oRes);
			}
		}

		// Token: 0x0600EE90 RID: 61072 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(EmptyData oArg)
		{
		}
	}
}
