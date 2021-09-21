using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200159F RID: 5535
	internal class Process_RpcC2M_WeddingInviteOperator
	{
		// Token: 0x0600EBA5 RID: 60325 RVA: 0x0034618C File Offset: 0x0034438C
		public static void OnReply(WeddingInviteOperatorArg oArg, WeddingInviteOperatorRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XWeddingDocument.Doc.OnWeddingInviteOperate(oArg, oRes);
				}
			}
		}

		// Token: 0x0600EBA6 RID: 60326 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(WeddingInviteOperatorArg oArg)
		{
		}
	}
}
