using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200156D RID: 5485
	internal class Process_RpcC2G_GetEnhanceAttr
	{
		// Token: 0x0600EACE RID: 60110 RVA: 0x00344DD4 File Offset: 0x00342FD4
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

		// Token: 0x0600EACF RID: 60111 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetEnhanceAttrArg oArg)
		{
		}
	}
}
