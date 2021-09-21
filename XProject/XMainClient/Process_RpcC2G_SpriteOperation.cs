using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200124C RID: 4684
	internal class Process_RpcC2G_SpriteOperation
	{
		// Token: 0x0600DE04 RID: 56836 RVA: 0x00332B50 File Offset: 0x00330D50
		public static void OnReply(SpriteOperationArg oArg, SpriteOperationRes oRes)
		{
			bool flag = oRes.ErrorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
				specificDocument.OnSpriteOperation(oArg, oRes);
			}
		}

		// Token: 0x0600DE05 RID: 56837 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SpriteOperationArg oArg)
		{
		}
	}
}
