using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001290 RID: 4752
	internal class Process_RpcC2M_MTShowTopList
	{
		// Token: 0x0600DF1E RID: 57118 RVA: 0x00334124 File Offset: 0x00332324
		public static void OnReply(TShowTopListArg oArg, TShowTopListRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
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
					bool flag3 = oRes.error == ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
					}
				}
			}
		}

		// Token: 0x0600DF1F RID: 57119 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(TShowTopListArg oArg)
		{
		}
	}
}
