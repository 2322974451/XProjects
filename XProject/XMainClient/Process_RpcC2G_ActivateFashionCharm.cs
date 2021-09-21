using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020014ED RID: 5357
	internal class Process_RpcC2G_ActivateFashionCharm
	{
		// Token: 0x0600E8C7 RID: 59591 RVA: 0x00341B58 File Offset: 0x0033FD58
		public static void OnReply(ActivateFashionArg oArg, ActivateFashionRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
				specificDocument.ReceiveActivateFashion(oArg, oRes);
			}
		}

		// Token: 0x0600E8C8 RID: 59592 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ActivateFashionArg oArg)
		{
		}
	}
}
