using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200134B RID: 4939
	internal class Process_RpcC2M_ResWarExplore
	{
		// Token: 0x0600E221 RID: 57889 RVA: 0x00338970 File Offset: 0x00336B70
		public static void OnReply(ResWarExploreArg oArg, ResWarExploreRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.error > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
					}
				}
			}
		}

		// Token: 0x0600E222 RID: 57890 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ResWarExploreArg oArg)
		{
		}
	}
}
