using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020015C4 RID: 5572
	internal class Process_RpcC2M_GetMarriageLiveness
	{
		// Token: 0x0600EC36 RID: 60470 RVA: 0x00346BF4 File Offset: 0x00344DF4
		public static void OnReply(GetMarriageLivenessArg oArg, GetMarriageLivenessRes oRes)
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
					XWeddingDocument.Doc.OnGetPartnerLivenessInfo(oRes);
				}
			}
		}

		// Token: 0x0600EC37 RID: 60471 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetMarriageLivenessArg oArg)
		{
		}
	}
}
