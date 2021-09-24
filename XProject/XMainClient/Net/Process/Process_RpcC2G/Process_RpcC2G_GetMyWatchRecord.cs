using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetMyWatchRecord
	{

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

		public static void OnTimeout(GetMyWatchRecordArg oArg)
		{
		}
	}
}
