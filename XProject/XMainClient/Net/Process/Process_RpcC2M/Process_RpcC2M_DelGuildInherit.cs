using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_DelGuildInherit
	{

		public static void OnReply(DelGuildInheritArg oArg, DelGuildInheritRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildInheritDocument specificDocument = XDocuments.GetSpecificDocument<XGuildInheritDocument>(XGuildInheritDocument.uuID);
				specificDocument.ReceiveDelInherit(oRes);
			}
		}

		public static void OnTimeout(DelGuildInheritArg oArg)
		{
		}
	}
}
