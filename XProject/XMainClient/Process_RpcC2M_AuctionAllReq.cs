using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001230 RID: 4656
	internal class Process_RpcC2M_AuctionAllReq
	{
		// Token: 0x0600DD8E RID: 56718 RVA: 0x003320FC File Offset: 0x003302FC
		public static void OnReply(AuctionAllReqArg oArg, AuctionAllReqRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				AuctionDocument specificDocument = XDocuments.GetSpecificDocument<AuctionDocument>(AuctionDocument.uuID);
				specificDocument.ReceiveAuctionResponse(oArg, oRes);
			}
		}

		// Token: 0x0600DD8F RID: 56719 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AuctionAllReqArg oArg)
		{
		}
	}
}
