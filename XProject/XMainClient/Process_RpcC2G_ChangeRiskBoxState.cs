using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200125F RID: 4703
	internal class Process_RpcC2G_ChangeRiskBoxState
	{
		// Token: 0x0600DE54 RID: 56916 RVA: 0x00333174 File Offset: 0x00331374
		public static void OnReply(ChangeRiskBoxStateArg oArg, ChangeRiskBoxStateRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSuperRiskDocument specificDocument = XDocuments.GetSpecificDocument<XSuperRiskDocument>(XSuperRiskDocument.uuID);
				specificDocument.OnBoxStateChangeSucc(oArg, oRes);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.error);
			}
		}

		// Token: 0x0600DE55 RID: 56917 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ChangeRiskBoxStateArg oArg)
		{
		}
	}
}
