using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_ReqGuildLadderRnakInfo
	{

		public static void OnReply(ReqGuildLadderRnakInfoArg oArg, ReqGuildLadderRnakInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				XGuildQualifierDocument specificDocument = XDocuments.GetSpecificDocument<XGuildQualifierDocument>(XGuildQualifierDocument.uuID);
				specificDocument.ReceiveGuildLandderRankList(oArg, oRes);
			}
		}

		public static void OnTimeout(ReqGuildLadderRnakInfoArg oArg)
		{
		}
	}
}
