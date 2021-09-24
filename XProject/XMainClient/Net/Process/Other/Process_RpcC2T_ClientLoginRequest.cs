using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2T_ClientLoginRequest
	{

		public static void OnReply(LoginArg oArg, LoginRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XSingleton<XDebug>.singleton.AddLog("Login Rpc Reply.", null, null, null, null, null, XDebugColor.XDebug_None);
				bool flag2 = oRes.result == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					Process_RpcC2T_ClientLoginRequest.ProcessAccountData(oRes.accountData);
					Process_RpcC2T_ClientLoginRequest.ProcessLoginExtraData(oRes.data);
					XSingleton<XLoginDocument>.singleton.EnterToSelectChar();
					XSingleton<XLoginDocument>.singleton.SetLoginReconnect(oRes.rinfo);
				}
				else
				{
					ErrorCode result = oRes.result;
					if (result != ErrorCode.ERR_LOGIN_VERIFY_FAILED)
					{
						if (result != ErrorCode.ERR_VERSION_FAILED)
						{
							if (result != ErrorCode.ERR_ACCOUNT_QUEUING)
							{
								XSingleton<XLoginDocument>.singleton.OnLoginFailed(XStringDefineProxy.GetString(oRes.result));
							}
							else
							{
								Process_RpcC2T_ClientLoginRequest.ProcessAccountData(oRes.accountData);
								XSingleton<XLoginDocument>.singleton.ShowServerQueue();
							}
						}
						else
						{
							XSingleton<XClientNetwork>.singleton.OnServerErrorNotify((uint)XFastEnumIntEqualityComparer<ErrorCode>.ToInt(oRes.result), oRes.version);
						}
					}
					else
					{
						XSingleton<XLoginDocument>.singleton.OnAuthorizedFailed();
					}
				}
			}
		}

		public static void OnTimeout(LoginArg oArg)
		{
			XSingleton<XDebug>.singleton.AddLog("Login Rpc Timeout.", null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo.Clear();
			XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.SelectedSlot = 0;
		}

		public static void ProcessAccountData(LoadAccountData roAccountData)
		{
			XSingleton<XAttributeMgr>.singleton.ProcessAccountData(roAccountData);
		}

		public static void ProcessLoginExtraData(LoginExtraData data)
		{
			XSingleton<XAttributeMgr>.singleton.ProcessLoginExtraData(data);
		}
	}
}
