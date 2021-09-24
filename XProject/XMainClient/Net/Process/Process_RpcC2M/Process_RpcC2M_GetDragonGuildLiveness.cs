using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GetDragonGuildLiveness
	{

		public static void OnReply(GetPartnerLivenessArg oArg, GetPartnerLivenessRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.result);
			}
			else
			{
				XDragonGuildDocument.DragonGuildLivenessData.OnGetDragonGuildLivenessInfoBack(oRes);
			}
		}

		public static void OnTimeout(GetPartnerLivenessArg oArg)
		{
		}
	}
}
