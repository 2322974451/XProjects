using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200146D RID: 5229
	internal class Process_RpcC2M_LeagueBattleReq
	{
		// Token: 0x0600E6BA RID: 59066 RVA: 0x0033EF14 File Offset: 0x0033D114
		public static void OnReply(LeagueBattleReqArg oArg, LeagueBattleReqRes oRes)
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

		// Token: 0x0600E6BB RID: 59067 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(LeagueBattleReqArg oArg)
		{
		}
	}
}
