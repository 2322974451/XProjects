using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020010E5 RID: 4325
	internal class Process_RpcC2G_ExpFindBack
	{
		// Token: 0x0600D84C RID: 55372 RVA: 0x00329594 File Offset: 0x00327794
		public static void OnReply(ExpFindBackArg oArg, ExpFindBackRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XFindExpDocument.Doc.OnReplyExpFindBack(oArg, oRes);
			}
		}

		// Token: 0x0600D84D RID: 55373 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ExpFindBackArg oArg)
		{
		}
	}
}
