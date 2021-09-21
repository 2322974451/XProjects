using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200115B RID: 4443
	internal class Process_RpcC2G_GetMyWatchRecord
	{
		// Token: 0x0600DA39 RID: 55865 RVA: 0x0032CDB4 File Offset: 0x0032AFB4
		public static void OnReply(GetMyWatchRecordArg oArg, GetMyWatchRecordRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.error > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
				}
				else
				{
					XSpectateDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID);
					specificDocument.SetMyLiveInfo(oRes.myWatchedNum, oRes.myCommendedNum, oRes.myMostWatchedRecord, oRes.myMostCommendedRecord, oRes.myRecentRecords, oRes.visibleSetting);
				}
			}
		}

		// Token: 0x0600DA3A RID: 55866 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetMyWatchRecordArg oArg)
		{
		}
	}
}
