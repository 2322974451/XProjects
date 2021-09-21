using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001248 RID: 4680
	internal class Process_RpcC2G_QueryIBItem
	{
		// Token: 0x0600DDF4 RID: 56820 RVA: 0x00332A20 File Offset: 0x00330C20
		public static void OnReply(IBQueryItemReq oArg, IBQueryItemRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XGameMallDocument specificDocument = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
				specificDocument.RespItems(oArg, oRes);
			}
		}

		// Token: 0x0600DDF5 RID: 56821 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(IBQueryItemReq oArg)
		{
		}
	}
}
