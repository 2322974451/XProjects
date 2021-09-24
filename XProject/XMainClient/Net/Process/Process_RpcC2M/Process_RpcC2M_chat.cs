using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_chat
	{

		public static void OnReply(ChatArg oArg, ChatRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.errorcode == ErrorCode.ERR_SUCCESS;
					if (!flag3)
					{
						bool flag4 = oRes.errorcode == ErrorCode.ERR_CHAT_TIMELIMIT;
						if (flag4)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("ERR_CHAT_TIMELIMIT"), XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)oRes.cooldown, 5)), "fece00");
						}
						else
						{
							bool flag5 = oRes.errorcode == ErrorCode.ERR_BLACK_INOTHER;
							if (flag5)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("ERR_BLACK_INOTHER"), new object[0]), "fece00");
							}
							else
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
							}
						}
					}
				}
			}
		}

		public static void OnTimeout(ChatArg oArg)
		{
		}
	}
}
