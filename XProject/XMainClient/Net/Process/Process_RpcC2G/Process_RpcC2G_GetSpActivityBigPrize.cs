using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetSpActivityBigPrize
	{

		public static void OnReply(GetSpActivityBigPrizeArg oArg, GetSpActivityBigPrizeRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XCarnivalDocument specificDocument = XDocuments.GetSpecificDocument<XCarnivalDocument>(XCarnivalDocument.uuID);
				specificDocument.RespExchange();
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.errorcode);
			}
		}

		public static void OnTimeout(GetSpActivityBigPrizeArg oArg)
		{
		}
	}
}
