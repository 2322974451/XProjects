using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020015E3 RID: 5603
	internal class Process_RpcC2M_EnterBattleReadyScene
	{
		// Token: 0x0600ECB7 RID: 60599 RVA: 0x00347688 File Offset: 0x00345888
		public static void OnReply(EnterBattleReadySceneArg oArg, EnterBattleReadySceneRes oRes)
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

		// Token: 0x0600ECB8 RID: 60600 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(EnterBattleReadySceneArg oArg)
		{
		}
	}
}
