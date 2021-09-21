using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020010E1 RID: 4321
	internal class Process_RpcC2G_BuyTeamSceneCount
	{
		// Token: 0x0600D83C RID: 55356 RVA: 0x00329458 File Offset: 0x00327658
		public static void OnReply(BuyTeamSceneCountP oArg, BuyTeamSceneCountRet oRes)
		{
			bool flag = oRes.errcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
				specificDocument.OnBuyCount(oArg, oRes);
			}
		}

		// Token: 0x0600D83D RID: 55357 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(BuyTeamSceneCountP oArg)
		{
		}
	}
}
