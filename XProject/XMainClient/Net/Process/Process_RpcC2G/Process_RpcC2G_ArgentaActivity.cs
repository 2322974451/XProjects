using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_ArgentaActivity
	{

		public static void OnReply(ArgentaActivityArg oArg, ArgentaActivityRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XWelfareDocument.Doc.OnGetArgentaActivityInfo(oArg, oRes);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
		}

		public static void OnTimeout(ArgentaActivityArg oArg)
		{
		}
	}
}
