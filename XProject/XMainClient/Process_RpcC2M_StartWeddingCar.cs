using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020015CD RID: 5581
	internal class Process_RpcC2M_StartWeddingCar
	{
		// Token: 0x0600EC5F RID: 60511 RVA: 0x00346FC0 File Offset: 0x003451C0
		public static void OnReply(StartWeddingCarArg oArg, StartWeddingCarRes oRes)
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

		// Token: 0x0600EC60 RID: 60512 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(StartWeddingCarArg oArg)
		{
		}
	}
}
