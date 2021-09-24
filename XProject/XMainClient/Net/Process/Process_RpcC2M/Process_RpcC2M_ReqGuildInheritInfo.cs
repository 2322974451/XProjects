using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_ReqGuildInheritInfo
	{

		public static void OnReply(ReqGuildInheritInfoArg oArg, ReqGuildInheritInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildInheritDocument specificDocument = XDocuments.GetSpecificDocument<XGuildInheritDocument>(XGuildInheritDocument.uuID);
				specificDocument.ReceiveInheritList(oArg, oRes);
			}
		}

		public static void OnTimeout(ReqGuildInheritInfoArg oArg)
		{
		}
	}
}
