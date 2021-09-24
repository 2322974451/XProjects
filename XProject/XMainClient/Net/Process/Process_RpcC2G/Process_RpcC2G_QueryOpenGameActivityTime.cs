using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_QueryOpenGameActivityTime
	{

		public static void OnReply(QueryOpenGameArg oArg, QueryOpenGameRes oRes)
		{
			bool flag = oRes.errcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XAchievementDocument specificDocument = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
				specificDocument.SetOpenServerActivityTime(oRes.timeLeft);
			}
		}

		public static void OnTimeout(QueryOpenGameArg oArg)
		{
		}
	}
}
