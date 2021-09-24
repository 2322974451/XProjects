using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_UpgradeEquip
	{

		public static void OnReply(UpgradeEquipArg oArg, UpgradeEquipRes oRes)
		{
			EquipUpgradeDocument.Doc.OnUpgradeBack(oRes);
		}

		public static void OnTimeout(UpgradeEquipArg oArg)
		{
		}
	}
}
