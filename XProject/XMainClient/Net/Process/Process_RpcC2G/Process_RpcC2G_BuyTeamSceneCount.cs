using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_BuyTeamSceneCount
	{

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

		public static void OnTimeout(BuyTeamSceneCountP oArg)
		{
		}
	}
}
