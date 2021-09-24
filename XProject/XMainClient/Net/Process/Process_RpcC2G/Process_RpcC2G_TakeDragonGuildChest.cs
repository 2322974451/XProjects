using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_TakeDragonGuildChest
	{

		public static void OnReply(TakePartnerChestArg oArg, TakePartnerChestRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.result);
			}
			else
			{
				XDragonGuildDocument.DragonGuildLivenessData.OnTakeDragonGuildChestBack(oArg, oRes);
			}
		}

		public static void OnTimeout(TakePartnerChestArg oArg)
		{
		}
	}
}
