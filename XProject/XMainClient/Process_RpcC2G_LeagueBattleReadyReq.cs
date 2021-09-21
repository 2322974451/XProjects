using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B67 RID: 2919
	internal class Process_RpcC2G_LeagueBattleReadyReq
	{
		// Token: 0x0600A916 RID: 43286 RVA: 0x001E1954 File Offset: 0x001DFB54
		public static void OnReply(LeagueBattleReadyReqArg oArg, LeagueBattleReadyReqRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.result > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
				}
			}
		}

		// Token: 0x0600A917 RID: 43287 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(LeagueBattleReadyReqArg oArg)
		{
		}
	}
}
