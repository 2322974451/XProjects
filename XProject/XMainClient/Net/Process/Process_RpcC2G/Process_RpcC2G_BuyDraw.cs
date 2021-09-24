using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_BuyDraw
	{

		public static void OnReply(BuyDrawReq oArg, BuyDrawRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				XOperatingActivityDocument specificDocument = XDocuments.GetSpecificDocument<XOperatingActivityDocument>(XOperatingActivityDocument.uuID);
				specificDocument.OnReceiveBuyLuckyTurntable();
			}
		}

		public static void OnTimeout(BuyDrawReq oArg)
		{
		}
	}
}
