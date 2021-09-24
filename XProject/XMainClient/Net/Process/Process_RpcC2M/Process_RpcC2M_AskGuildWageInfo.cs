using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_AskGuildWageInfo
	{

		public static void OnReply(AskGuildWageInfoArg oArg, AskGuildWageInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildSalaryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSalaryDocument>(XGuildSalaryDocument.uuID);
				specificDocument.ReceiveAskGuildWageInfo(oRes);
			}
		}

		public static void OnTimeout(AskGuildWageInfoArg oArg)
		{
		}
	}
}
