using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001542 RID: 5442
	internal class Process_RpcC2G_MobaSignaling
	{
		// Token: 0x0600EA1E RID: 59934 RVA: 0x00343BF0 File Offset: 0x00341DF0
		public static void OnReply(MobaSignalingArg oArg, MobaSignalingRes oRes)
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

		// Token: 0x0600EA1F RID: 59935 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(MobaSignalingArg oArg)
		{
		}
	}
}
