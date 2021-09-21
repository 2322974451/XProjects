using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020015B4 RID: 5556
	internal class Process_RpcC2G_TactEnterScene
	{
		// Token: 0x0600EBF6 RID: 60406 RVA: 0x003466C4 File Offset: 0x003448C4
		public static void OnReply(TactEnterSceneArg oArg, TactEnterSceneRes oRes)
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

		// Token: 0x0600EBF7 RID: 60407 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(TactEnterSceneArg oArg)
		{
		}
	}
}
