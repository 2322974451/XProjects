using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_ChangeRiskBoxState
	{

		public static void OnReply(ChangeRiskBoxStateArg oArg, ChangeRiskBoxStateRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSuperRiskDocument specificDocument = XDocuments.GetSpecificDocument<XSuperRiskDocument>(XSuperRiskDocument.uuID);
				specificDocument.OnBoxStateChangeSucc(oArg, oRes);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.error);
			}
		}

		public static void OnTimeout(ChangeRiskBoxStateArg oArg)
		{
		}
	}
}
