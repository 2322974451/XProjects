using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001544 RID: 5444
	internal class Process_RpcC2G_ActivateHairColor
	{
		// Token: 0x0600EA27 RID: 59943 RVA: 0x00343CD4 File Offset: 0x00341ED4
		public static void OnReply(ActivateHairColorArg oArg, ActivateHairColorRes oRes)
		{
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			specificDocument.SetActivateHairColor(oRes);
		}

		// Token: 0x0600EA28 RID: 59944 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ActivateHairColorArg oArg)
		{
		}
	}
}
