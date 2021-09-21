using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B61 RID: 2913
	internal class Process_RpcC2M_AskGuildWageInfo
	{
		// Token: 0x0600A908 RID: 43272 RVA: 0x001E183C File Offset: 0x001DFA3C
		public static void OnReply(AskGuildWageInfoArg oArg, AskGuildWageInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildSalaryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSalaryDocument>(XGuildSalaryDocument.uuID);
				specificDocument.ReceiveAskGuildWageInfo(oRes);
			}
		}

		// Token: 0x0600A909 RID: 43273 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AskGuildWageInfoArg oArg)
		{
		}
	}
}
