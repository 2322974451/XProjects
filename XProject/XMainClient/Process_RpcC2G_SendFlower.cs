using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001074 RID: 4212
	internal class Process_RpcC2G_SendFlower
	{
		// Token: 0x0600D68B RID: 54923 RVA: 0x00326418 File Offset: 0x00324618
		public static void OnReply(SendFlowerArg oArg, SendFlowerRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XFlowerSendDocument specificDocument = XDocuments.GetSpecificDocument<XFlowerSendDocument>(XFlowerSendDocument.uuID);
				specificDocument.OnSendFlower(oArg, oRes);
			}
		}

		// Token: 0x0600D68C RID: 54924 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SendFlowerArg oArg)
		{
		}
	}
}
