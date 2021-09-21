using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200139A RID: 5018
	internal class Process_RpcC2M_AddGuildInherit
	{
		// Token: 0x0600E363 RID: 58211 RVA: 0x0033A4A4 File Offset: 0x003386A4
		public static void OnReply(AddGuildInheritArg oArg, AddGuildInheritRes oRes)
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
					specificDocument.ReceiveReqInherit(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E364 RID: 58212 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AddGuildInheritArg oArg)
		{
		}
	}
}
