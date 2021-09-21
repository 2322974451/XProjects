using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020014C8 RID: 5320
	internal class Process_RpcC2G_ArgentaActivity
	{
		// Token: 0x0600E829 RID: 59433 RVA: 0x00340FC0 File Offset: 0x0033F1C0
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

		// Token: 0x0600E82A RID: 59434 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ArgentaActivityArg oArg)
		{
		}
	}
}
