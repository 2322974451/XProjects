using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_ForgeEquip
	{

		public static void OnReply(ForgeEquipArg oArg, ForgeEquipRes oRes)
		{
			XForgeDocument.Doc.OnForgeEquipBack(oArg.type, oRes);
		}

		public static void OnTimeout(ForgeEquipArg oArg)
		{
		}
	}
}
