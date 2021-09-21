using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200152C RID: 5420
	internal class Process_RpcC2G_WeekEnd4v4GetInfo
	{
		// Token: 0x0600E9CB RID: 59851 RVA: 0x003433A4 File Offset: 0x003415A4
		public static void OnReply(WeekEnd4v4GetInfoArg oArg, WeekEnd4v4GetInfoRes oRes)
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
					XWeekendPartyDocument specificDocument = XDocuments.GetSpecificDocument<XWeekendPartyDocument>(XWeekendPartyDocument.uuID);
					specificDocument.OnGetWeekendPartyInfo(oRes);
				}
			}
		}

		// Token: 0x0600E9CC RID: 59852 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(WeekEnd4v4GetInfoArg oArg)
		{
		}
	}
}
