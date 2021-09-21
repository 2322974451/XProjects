using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001197 RID: 4503
	internal class Process_RpcC2M_chat
	{
		// Token: 0x0600DB23 RID: 56099 RVA: 0x0032E8E8 File Offset: 0x0032CAE8
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

		// Token: 0x0600DB24 RID: 56100 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ChatArg oArg)
		{
		}
	}
}
