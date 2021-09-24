using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_FuseEquip
	{

		public static void OnReply(FuseEquipArg oArg, FuseEquipRes oRes)
		{
			EquipFusionDocument.Doc.OnGetEquipFuseInfo(oRes);
		}

		public static void OnTimeout(FuseEquipArg oArg)
		{
		}
	}
}
