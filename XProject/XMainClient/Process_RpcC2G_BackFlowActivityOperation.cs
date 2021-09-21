using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200166C RID: 5740
	internal class Process_RpcC2G_BackFlowActivityOperation
	{
		// Token: 0x0600EEFD RID: 61181 RVA: 0x0034A858 File Offset: 0x00348A58
		public static void OnReply(BackFlowActivityOperationArg oArg, BackFlowActivityOperationRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XBackFlowDocument.Doc.OnGetBackFlowOperation(oArg, oRes);
			}
		}

		// Token: 0x0600EEFE RID: 61182 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(BackFlowActivityOperationArg oArg)
		{
		}
	}
}
