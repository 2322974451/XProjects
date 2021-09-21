using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001109 RID: 4361
	internal class Process_RpcC2G_GetAchievePointRewardReq
	{
		// Token: 0x0600D8E3 RID: 55523 RVA: 0x0032A2E4 File Offset: 0x003284E4
		public static void OnReply(GetAchievePointRewardReq oArg, GetAchievePointRewardRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
				else
				{
					XDesignationDocument xdesignationDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XDesignationDocument.uuID) as XDesignationDocument;
					xdesignationDocument.FetchAchieveSurvey();
				}
			}
		}

		// Token: 0x0600D8E4 RID: 55524 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetAchievePointRewardReq oArg)
		{
		}
	}
}
