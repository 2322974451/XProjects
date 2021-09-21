using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001621 RID: 5665
	internal class Process_RpcC2M_GetDragonGuildLiveness
	{
		// Token: 0x0600EDBF RID: 60863 RVA: 0x00348C6C File Offset: 0x00346E6C
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

		// Token: 0x0600EDC0 RID: 60864 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetPartnerLivenessArg oArg)
		{
		}
	}
}
