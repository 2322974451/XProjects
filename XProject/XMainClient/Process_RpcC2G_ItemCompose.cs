using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020014C0 RID: 5312
	internal class Process_RpcC2G_ItemCompose
	{
		// Token: 0x0600E809 RID: 59401 RVA: 0x00340CF8 File Offset: 0x0033EEF8
		public static void OnReply(ItemComposeArg oArg, ItemComposeRes oRes)
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
					XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.errorcode);
				}
			}
		}

		// Token: 0x0600E80A RID: 59402 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ItemComposeArg oArg)
		{
		}
	}
}
