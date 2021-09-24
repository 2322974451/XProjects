using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_AskDragonGuildMembers
	{

		public static void OnReply(DragonGuildMemberArg oArg, DragonGuildMemberRes oRes)
		{
			XDragonGuildDocument.Doc.OnGetMemberList(oRes);
		}

		public static void OnTimeout(DragonGuildMemberArg oArg)
		{
		}
	}
}
