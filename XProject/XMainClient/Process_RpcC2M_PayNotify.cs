using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200133A RID: 4922
	internal class Process_RpcC2M_PayNotify
	{
		// Token: 0x0600E1D8 RID: 57816 RVA: 0x00338314 File Offset: 0x00336514
		public static void OnReply(PayNotifyArg oArg, PayNotifyRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
					specificDocument.OnPayNotify(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E1D9 RID: 57817 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(PayNotifyArg oArg)
		{
		}
	}
}
