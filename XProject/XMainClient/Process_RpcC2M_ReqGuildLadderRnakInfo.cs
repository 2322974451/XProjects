using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012D5 RID: 4821
	internal class Process_RpcC2M_ReqGuildLadderRnakInfo
	{
		// Token: 0x0600E037 RID: 57399 RVA: 0x00335B10 File Offset: 0x00333D10
		public static void OnReply(ReqGuildLadderRnakInfoArg oArg, ReqGuildLadderRnakInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				XGuildQualifierDocument specificDocument = XDocuments.GetSpecificDocument<XGuildQualifierDocument>(XGuildQualifierDocument.uuID);
				specificDocument.ReceiveGuildLandderRankList(oArg, oRes);
			}
		}

		// Token: 0x0600E038 RID: 57400 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ReqGuildLadderRnakInfoArg oArg)
		{
		}
	}
}
