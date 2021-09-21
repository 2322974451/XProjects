using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200160C RID: 5644
	internal class Process_RpcC2G_BuyDraw
	{
		// Token: 0x0600ED64 RID: 60772 RVA: 0x0034841C File Offset: 0x0034661C
		public static void OnReply(BuyDrawReq oArg, BuyDrawRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				XOperatingActivityDocument specificDocument = XDocuments.GetSpecificDocument<XOperatingActivityDocument>(XOperatingActivityDocument.uuID);
				specificDocument.OnReceiveBuyLuckyTurntable();
			}
		}

		// Token: 0x0600ED65 RID: 60773 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(BuyDrawReq oArg)
		{
		}
	}
}
