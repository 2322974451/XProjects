using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001320 RID: 4896
	internal class Process_RpcC2G_GetSpActivityBigPrize
	{
		// Token: 0x0600E16F RID: 57711 RVA: 0x00337938 File Offset: 0x00335B38
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

		// Token: 0x0600E170 RID: 57712 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetSpActivityBigPrizeArg oArg)
		{
		}
	}
}
