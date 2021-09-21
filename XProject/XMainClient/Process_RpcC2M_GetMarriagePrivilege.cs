using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001697 RID: 5783
	internal class Process_RpcC2M_GetMarriagePrivilege
	{
		// Token: 0x0600EFB5 RID: 61365 RVA: 0x0034BC98 File Offset: 0x00349E98
		public static void OnReply(GetMarriagePrivilegeArg oArg, GetMarriagePrivilegeRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XWeddingDocument.Doc.OnGetMarriagePrivilege(oRes.error);
				}
			}
		}

		// Token: 0x0600EFB6 RID: 61366 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetMarriagePrivilegeArg oArg)
		{
		}
	}
}
