using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200116B RID: 4459
	internal class Process_RpcC2G_TakeOffAllJade
	{
		// Token: 0x0600DA81 RID: 55937 RVA: 0x0032DBE8 File Offset: 0x0032BDE8
		public static void OnReply(TakeOffAllJadeArg oArg, TakeOffAllJadeRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
			}
		}

		// Token: 0x0600DA82 RID: 55938 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(TakeOffAllJadeArg oArg)
		{
		}
	}
}
