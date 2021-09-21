using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020010F6 RID: 4342
	internal class Process_RpcC2G_GetAchieveBrifInfoReq
	{
		// Token: 0x0600D893 RID: 55443 RVA: 0x00329C44 File Offset: 0x00327E44
		public static void OnReply(GetAchieveBrifInfoReq oArg, GetAchieveBrifInfoRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XDesignationDocument specificDocument = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
				specificDocument.OnResAchieveSurvey(oRes);
			}
		}

		// Token: 0x0600D894 RID: 55444 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetAchieveBrifInfoReq oArg)
		{
		}
	}
}
