using System;
using System.Reflection;
using KKSG;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001147 RID: 4423
	internal class Process_RpcC2M_SelectRoleNew
	{
		// Token: 0x0600D9E7 RID: 55783 RVA: 0x0032BCC0 File Offset: 0x00329EC0
		public static void OnReply(SelectRoleNewArg oArg, SelectRoleNewRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.result == ErrorCode.ERR_SUCCESS;
					if (!flag3)
					{
						bool flag4 = oRes.result == ErrorCode.ERR_LOGIN_FORBID;
						if (flag4)
						{
							string format = oRes.reason + "\n" + XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString(oRes.result.ToString()));
							XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(format, XSingleton<UiUtility>.singleton.TimeAccFormatString(oRes.banTime, 2, 0), XSingleton<UiUtility>.singleton.TimeFormatSince1970(oRes.endTime, XStringDefineProxy.GetString("IDIP_TIPS_TIME"), true)), XStringDefineProxy.GetString("COMMON_OK"), new ButtonClickEventHandler(XSingleton<XLoginDocument>.singleton.OnLoginForbidClick), 300);
						}
						else
						{
							bool flag5 = oRes.result == ErrorCode.ERR_PLAT_BANACC;
							if (flag5)
							{
								string format2 = oRes.reason + "\n" + XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString(oRes.result.ToString()));
								XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(format2, XSingleton<UiUtility>.singleton.TimeFormatSince1970(oRes.endTime, XStringDefineProxy.GetString("IDIP_TIPS_TIME"), true)), XStringDefineProxy.GetString("COMMON_OK"), new ButtonClickEventHandler(XSingleton<XLoginDocument>.singleton.OnLoginForbidClick), 300);
							}
							else
							{
								bool flag6 = oRes.result == ErrorCode.ERR_HG_FORBID;
								if (flag6)
								{
									string reason = oRes.reason;
									XSingleton<UiUtility>.singleton.ShowModalDialog(reason, XStringDefineProxy.GetString("COMMON_OK"), new ButtonClickEventHandler(XSingleton<XLoginDocument>.singleton.OnLoginForbidClick), 300);
								}
								else
								{
									string @string = XStringDefineProxy.GetString(oRes.result);
									XSingleton<XLoginDocument>.singleton.OnEnterWorldFailed(@string);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600D9E8 RID: 55784 RVA: 0x0032BEE4 File Offset: 0x0032A0E4
		public static void OnTimeout(SelectRoleNewArg oArg)
		{
			XSingleton<XDebug>.singleton.AddLog("rpc Select Role Timeout.", null, null, null, null, null, XDebugColor.XDebug_None);
		}
	}
}
