using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020015AE RID: 5550
	internal class Process_RpcC2G_WeddingOperator
	{
		// Token: 0x0600EBDF RID: 60383 RVA: 0x00346540 File Offset: 0x00344740
		public static void OnReply(WeddingOperatorArg oArg, WeddingOperatorRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XWeddingDocument.Doc.OnWeddingSceneOperator(oArg, oRes);
			}
		}

		// Token: 0x0600EBE0 RID: 60384 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(WeddingOperatorArg oArg)
		{
		}
	}
}
