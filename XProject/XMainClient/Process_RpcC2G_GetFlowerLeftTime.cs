using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200112A RID: 4394
	internal class Process_RpcC2G_GetFlowerLeftTime
	{
		// Token: 0x0600D96A RID: 55658 RVA: 0x0032B12C File Offset: 0x0032932C
		public static void OnReply(GetFlowerLeftTimeArg oArg, GetFlowerLeftTimeRes oRes)
		{
			bool flag = oRes.errorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
				specificDocument.OnGetFlowerLeftTime(oRes);
			}
		}

		// Token: 0x0600D96B RID: 55659 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetFlowerLeftTimeArg oArg)
		{
		}
	}
}
