using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200106B RID: 4203
	internal class Process_RpcC2G_QueryOpenGameActivityTime
	{
		// Token: 0x0600D664 RID: 54884 RVA: 0x00326034 File Offset: 0x00324234
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

		// Token: 0x0600D665 RID: 54885 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(QueryOpenGameArg oArg)
		{
		}
	}
}
