using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200152A RID: 5418
	internal class Process_RpcC2G_GetPlatShareAward
	{
		// Token: 0x0600E9C2 RID: 59842 RVA: 0x003432A8 File Offset: 0x003414A8
		public static void OnReply(GetPlatShareAwardArg oArg, GetPlatShareAwardRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XAchievementDocument specificDocument = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
					specificDocument.OnGetPlatShareAward();
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
			}
		}

		// Token: 0x0600E9C3 RID: 59843 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetPlatShareAwardArg oArg)
		{
		}
	}
}
