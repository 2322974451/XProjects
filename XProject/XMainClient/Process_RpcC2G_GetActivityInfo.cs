using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020011D9 RID: 4569
	internal class Process_RpcC2G_GetActivityInfo
	{
		// Token: 0x0600DC2D RID: 56365 RVA: 0x0032FF58 File Offset: 0x0032E158
		public static void OnReply(GetActivityInfoArg oArg, GetActivityInfoRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
				else
				{
					XDailyActivitiesDocument specificDocument = XDocuments.GetSpecificDocument<XDailyActivitiesDocument>(XDailyActivitiesDocument.uuID);
					specificDocument.GetDailyActivityData(oRes.Record);
				}
			}
		}

		// Token: 0x0600DC2E RID: 56366 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetActivityInfoArg oArg)
		{
		}
	}
}
