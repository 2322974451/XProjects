using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001483 RID: 5251
	internal class Process_RpcC2M_SetSubscribe
	{
		// Token: 0x0600E711 RID: 59153 RVA: 0x0033F794 File Offset: 0x0033D994
		public static void OnReply(SetSubscirbeArg oArg, SetSubscribeRes oRes)
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
					bool flag3 = oRes.result > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
					else
					{
						XPushSubscribeDocument specificDocument = XDocuments.GetSpecificDocument<XPushSubscribeDocument>(XPushSubscribeDocument.uuID);
						specificDocument.OnSetSubscribe(oArg);
					}
				}
			}
		}

		// Token: 0x0600E712 RID: 59154 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SetSubscirbeArg oArg)
		{
		}
	}
}
