using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001641 RID: 5697
	internal class Process_RpcC2M_GetDragonGuildShop
	{
		// Token: 0x0600EE49 RID: 61001 RVA: 0x003498F0 File Offset: 0x00347AF0
		public static void OnReply(GetDragonGuildShopArg oArg, GetDragonGuildShopRes oRes)
		{
			XNormalShopDocument specificDocument = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
			specificDocument.OnGetGoodsList(oArg, oRes);
		}

		// Token: 0x0600EE4A RID: 61002 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetDragonGuildShopArg oArg)
		{
		}
	}
}
