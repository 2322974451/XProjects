using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020010CE RID: 4302
	internal class Process_RpcC2G_UseSupplement
	{
		// Token: 0x0600D7F0 RID: 55280 RVA: 0x00328D60 File Offset: 0x00326F60
		public static void OnReply(UseSupplementReq oArg, UseSupplementRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
		}

		// Token: 0x0600D7F1 RID: 55281 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(UseSupplementReq oArg)
		{
		}
	}
}
