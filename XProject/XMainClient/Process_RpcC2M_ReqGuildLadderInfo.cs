using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012D3 RID: 4819
	internal class Process_RpcC2M_ReqGuildLadderInfo
	{
		// Token: 0x0600E02E RID: 57390 RVA: 0x00335A54 File Offset: 0x00333C54
		public static void OnReply(ReqGuildLadderInfoAgr oArg, ReqGuildLadderInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildQualifierDocument specificDocument = XDocuments.GetSpecificDocument<XGuildQualifierDocument>(XGuildQualifierDocument.uuID);
				specificDocument.ReceiveSelectQualifierList(oArg, oRes);
			}
		}

		// Token: 0x0600E02F RID: 57391 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ReqGuildLadderInfoAgr oArg)
		{
		}
	}
}
