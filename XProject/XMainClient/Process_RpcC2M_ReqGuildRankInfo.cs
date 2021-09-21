using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200130C RID: 4876
	internal class Process_RpcC2M_ReqGuildRankInfo
	{
		// Token: 0x0600E11B RID: 57627 RVA: 0x00337090 File Offset: 0x00335290
		public static void OnReply(ReqGuildRankInfoArg oArg, ReqGuildRankInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildRankDocument specificDocument = XDocuments.GetSpecificDocument<XGuildRankDocument>(XGuildRankDocument.uuID);
				specificDocument.ReceiveGuildRankInfo(oRes);
			}
		}

		// Token: 0x0600E11C RID: 57628 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ReqGuildRankInfoArg oArg)
		{
		}
	}
}
