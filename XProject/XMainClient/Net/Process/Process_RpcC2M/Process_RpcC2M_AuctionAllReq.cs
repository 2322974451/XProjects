using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_AuctionAllReq
	{

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

		public static void OnTimeout(AuctionAllReqArg oArg)
		{
		}
	}
}
