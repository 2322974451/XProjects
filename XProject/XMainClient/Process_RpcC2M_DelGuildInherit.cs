using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020013A2 RID: 5026
	internal class Process_RpcC2M_DelGuildInherit
	{
		// Token: 0x0600E385 RID: 58245 RVA: 0x0033A7B4 File Offset: 0x003389B4
		public static void OnReply(DelGuildInheritArg oArg, DelGuildInheritRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildInheritDocument specificDocument = XDocuments.GetSpecificDocument<XGuildInheritDocument>(XGuildInheritDocument.uuID);
				specificDocument.ReceiveDelInherit(oRes);
			}
		}

		// Token: 0x0600E386 RID: 58246 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(DelGuildInheritArg oArg)
		{
		}
	}
}
