using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200128D RID: 4749
	internal class Process_RpcC2G_LearnGuildSkill
	{
		// Token: 0x0600DF10 RID: 57104 RVA: 0x00334034 File Offset: 0x00332234
		public static void OnReply(LearnGuildSkillAgr oArg, LearnGuildSkillRes oRes)
		{
			XGuildSkillDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSkillDocument>(XGuildSkillDocument.uuID);
			specificDocument.ReceiveLearnGuildSKill(oArg, oRes);
		}

		// Token: 0x0600DF11 RID: 57105 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(LearnGuildSkillAgr oArg)
		{
		}
	}
}
