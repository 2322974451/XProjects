using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001689 RID: 5769
	internal class Process_RpcC2M_GetDanceIds
	{
		// Token: 0x0600EF76 RID: 61302 RVA: 0x0034B58C File Offset: 0x0034978C
		public static void OnReply(GetDanceIdsArg oArg, GetDanceIdsRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XDanceDocument.Doc.OnGetDanceIDs(oRes);
			}
		}

		// Token: 0x0600EF77 RID: 61303 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetDanceIdsArg oArg)
		{
		}
	}
}
