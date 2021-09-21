using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001519 RID: 5401
	internal class Process_RpcC2M_KMatchCommonReq
	{
		// Token: 0x0600E97D RID: 59773 RVA: 0x00342C84 File Offset: 0x00340E84
		public static void OnReply(KMatchCommonArg oArg, KMatchCommonRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
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
					bool flag3 = oRes.errorcode == ErrorCode.ERR_REPORT_FORBID;
					if (flag3)
					{
						string arg = XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)oRes.endtime, XStringDefineProxy.GetString("IDIP_TIPS_TIME"), true);
						string text = string.Format(XStringDefineProxy.GetString("PVP_BANNED_TIPS"), oRes.problem_name, arg);
						XSingleton<UiUtility>.singleton.ShowSystemTip(text, "fece00");
					}
					else
					{
						bool flag4 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
						if (flag4)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
						}
					}
				}
			}
		}

		// Token: 0x0600E97E RID: 59774 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(KMatchCommonArg oArg)
		{
		}
	}
}
