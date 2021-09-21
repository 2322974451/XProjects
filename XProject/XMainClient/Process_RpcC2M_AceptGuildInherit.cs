using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200139C RID: 5020
	internal class Process_RpcC2M_AceptGuildInherit
	{
		// Token: 0x0600E36C RID: 58220 RVA: 0x0033A590 File Offset: 0x00338790
		public static void OnReply(AceptGuildInheritArg oArg, AceptGuildInheritRes oRes)
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
					XGuildInheritDocument specificDocument = XDocuments.GetSpecificDocument<XGuildInheritDocument>(XGuildInheritDocument.uuID);
					specificDocument.ReceiveAccpetInherit(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E36D RID: 58221 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AceptGuildInheritArg oArg)
		{
		}
	}
}
