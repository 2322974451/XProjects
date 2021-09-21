using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012AC RID: 4780
	internal class Process_RpcC2M_QueryGuildCheckinNew
	{
		// Token: 0x0600DF90 RID: 57232 RVA: 0x00334C6C File Offset: 0x00332E6C
		public static void OnReply(QueryGuildCheckinArg oArg, QueryGuildCheckinRes oRes)
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
					XGuildSignInDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSignInDocument>(XGuildSignInDocument.uuID);
					specificDocument.OnGetAllInfo(oRes);
				}
			}
		}

		// Token: 0x0600DF91 RID: 57233 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(QueryGuildCheckinArg oArg)
		{
		}
	}
}
