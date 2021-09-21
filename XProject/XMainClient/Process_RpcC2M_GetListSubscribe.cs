using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001481 RID: 5249
	internal class Process_RpcC2M_GetListSubscribe
	{
		// Token: 0x0600E708 RID: 59144 RVA: 0x0033F6A0 File Offset: 0x0033D8A0
		public static void OnReply(GetListSubscribeArg oArg, GetListSubscribeRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
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
					XPushSubscribeDocument specificDocument = XDocuments.GetSpecificDocument<XPushSubscribeDocument>(XPushSubscribeDocument.uuID);
					specificDocument.OnListSubscribe(oRes.list);
				}
			}
		}

		// Token: 0x0600E709 RID: 59145 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetListSubscribeArg oArg)
		{
		}
	}
}
