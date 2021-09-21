using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012E3 RID: 4835
	internal class Process_RpcC2M_FriendGardenPlantLog
	{
		// Token: 0x0600E074 RID: 57460 RVA: 0x00336134 File Offset: 0x00334334
		public static void OnReply(FriendGardenPlantLogArg oArg, FriendGardenPlantLogRes oRes)
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
					HomeMainDocument.Doc.OnGetPlantFriendList(oRes);
				}
			}
		}

		// Token: 0x0600E075 RID: 57461 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(FriendGardenPlantLogArg oArg)
		{
		}
	}
}
