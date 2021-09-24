using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_LearnGuildSkill
	{

		public static void OnReply(LearnGuildSkillAgr oArg, LearnGuildSkillRes oRes)
		{
			XGuildSkillDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSkillDocument>(XGuildSkillDocument.uuID);
			specificDocument.ReceiveLearnGuildSKill(oArg, oRes);
		}

		public static void OnTimeout(LearnGuildSkillAgr oArg)
		{
		}
	}
}
