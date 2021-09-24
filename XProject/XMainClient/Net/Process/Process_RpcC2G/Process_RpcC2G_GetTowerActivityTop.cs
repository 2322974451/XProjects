using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_GetTowerActivityTop
	{

		public static void OnReply(GetTowerActivityTopArg oArg, GetTowerActivityTopRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
			if (!flag)
			{
				XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
				specificDocument.GetSingleTowerActivityTopRes(oRes);
			}
		}

		public static void OnTimeout(GetTowerActivityTopArg oArg)
		{
		}
	}
}
