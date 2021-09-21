using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000ECC RID: 3788
	internal class Process_RpcC2T_Reconnect
	{
		// Token: 0x0600C8C9 RID: 51401 RVA: 0x002CF3A4 File Offset: 0x002CD5A4
		public static void OnReply(ReconnArg oArg, ReconnRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool onReconnect = XSingleton<XClientNetwork>.singleton.XConnect.OnReconnect;
				if (onReconnect)
				{
					bool flag2 = oRes.result == ErrorCode.ERR_SUCCESS;
					if (flag2)
					{
						XSingleton<XClientNetwork>.singleton.XConnect.OnReconnected();
					}
					else
					{
						XSingleton<XClientNetwork>.singleton.XConnect.OnReconnectFailed();
					}
				}
			}
		}

		// Token: 0x0600C8CA RID: 51402 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ReconnArg oArg)
		{
		}
	}
}
