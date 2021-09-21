using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200160E RID: 5646
	internal class Process_RpcC2G_LotteryDraw
	{
		// Token: 0x0600ED6D RID: 60781 RVA: 0x003484E4 File Offset: 0x003466E4
		public static void OnReply(LotteryDrawReq oArg, LotteryDrawRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				XOperatingActivityDocument specificDocument = XDocuments.GetSpecificDocument<XOperatingActivityDocument>(XOperatingActivityDocument.uuID);
				specificDocument.OnReceiveUseLuckyTurntable(oRes);
			}
		}

		// Token: 0x0600ED6E RID: 60782 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(LotteryDrawReq oArg)
		{
		}
	}
}
