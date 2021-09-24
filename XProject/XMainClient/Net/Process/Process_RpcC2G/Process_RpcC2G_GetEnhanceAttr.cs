using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetEnhanceAttr
	{

		public static void OnReply(GetEnhanceAttrArg oArg, GetEnhanceAttrRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				XEnhanceDocument.Doc.OnReqEnhanceAttrBack(oArg, oRes);
			}
		}

		public static void OnTimeout(GetEnhanceAttrArg oArg)
		{
		}
	}
}
