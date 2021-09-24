using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_ReqGuildRankInfo
	{

		public static void OnReply(ReqGuildRankInfoArg oArg, ReqGuildRankInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildRankDocument specificDocument = XDocuments.GetSpecificDocument<XGuildRankDocument>(XGuildRankDocument.uuID);
				specificDocument.ReceiveGuildRankInfo(oRes);
			}
		}

		public static void OnTimeout(ReqGuildRankInfoArg oArg)
		{
		}
	}
}
