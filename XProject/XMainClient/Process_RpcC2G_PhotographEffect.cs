using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020013FF RID: 5119
	internal class Process_RpcC2G_PhotographEffect
	{
		// Token: 0x0600E500 RID: 58624 RVA: 0x0033C63C File Offset: 0x0033A83C
		public static void OnReply(PhotographEffectArg oArg, PhotographEffect oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XScreenShotShareDocument specificDocument = XDocuments.GetSpecificDocument<XScreenShotShareDocument>(XScreenShotShareDocument.uuID);
				specificDocument.OnGetPhotoGraphEffect(oRes);
			}
		}

		// Token: 0x0600E501 RID: 58625 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(PhotographEffectArg oArg)
		{
		}
	}
}
