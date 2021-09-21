using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200112C RID: 4396
	internal class Process_RpcC2G_GetFlower
	{
		// Token: 0x0600D973 RID: 55667 RVA: 0x0032B204 File Offset: 0x00329404
		public static void OnReply(GetFlowerArg oArg, GetFlowerRes oRes)
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
				specificDocument.OnGetFlower(oRes);
			}
		}

		// Token: 0x0600D974 RID: 55668 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetFlowerArg oArg)
		{
		}
	}
}
