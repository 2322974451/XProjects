using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2T_Reconnect
	{

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

		public static void OnTimeout(ReconnArg oArg)
		{
		}
	}
}
