using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012E7 RID: 4839
	internal class Process_RpcC2M_SkyCityEnter
	{
		// Token: 0x0600E086 RID: 57478 RVA: 0x00336338 File Offset: 0x00334538
		public static void OnReply(SkyCityEnterArg oArg, SkyCityEnterRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.error > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
				}
			}
		}

		// Token: 0x0600E087 RID: 57479 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SkyCityEnterArg oArg)
		{
		}
	}
}
