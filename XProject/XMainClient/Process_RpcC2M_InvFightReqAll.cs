using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020013F5 RID: 5109
	internal class Process_RpcC2M_InvFightReqAll
	{
		// Token: 0x0600E4D9 RID: 58585 RVA: 0x0033C310 File Offset: 0x0033A510
		public static void OnReply(InvFightArg oArg, InvFightRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XPKInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XPKInvitationDocument>(XPKInvitationDocument.uuID);
					specificDocument.OnGetPKInfo(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E4DA RID: 58586 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(InvFightArg oArg)
		{
		}
	}
}
