using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_ReqGuildLadderInfo
	{

		public static void OnReply(ReqGuildLadderInfoAgr oArg, ReqGuildLadderInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildQualifierDocument specificDocument = XDocuments.GetSpecificDocument<XGuildQualifierDocument>(XGuildQualifierDocument.uuID);
				specificDocument.ReceiveSelectQualifierList(oArg, oRes);
			}
		}

		public static void OnTimeout(ReqGuildLadderInfoAgr oArg)
		{
		}
	}
}
