using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B6F RID: 2927
	internal class Process_RpcC2M_ChangeNameNew
	{
		// Token: 0x0600A92A RID: 43306 RVA: 0x001E1C14 File Offset: 0x001DFE14
		public static void OnReply(ChangeNameArg oArg, ChangeNameRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XRenameDocument specificDocument = XDocuments.GetSpecificDocument<XRenameDocument>(XRenameDocument.uuID);
				specificDocument.ReceivePlayerCostRename(oArg, oRes);
			}
		}

		// Token: 0x0600A92B RID: 43307 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ChangeNameArg oArg)
		{
		}
	}
}
