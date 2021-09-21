using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001494 RID: 5268
	internal class Process_RpcC2G_EnchantTransfer
	{
		// Token: 0x0600E758 RID: 59224 RVA: 0x0033FE10 File Offset: 0x0033E010
		public static void OnReply(EnchantTransferArg oArg, EnchantTransferRes oRes)
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

		// Token: 0x0600E759 RID: 59225 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(EnchantTransferArg oArg)
		{
		}
	}
}
