using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200123A RID: 4666
	internal class Process_RpcC2G_ItemFindBack
	{
		// Token: 0x0600DDB7 RID: 56759 RVA: 0x0033241C File Offset: 0x0033061C
		public static void OnReply(ItemFindBackArg oArg, ItemFindBackRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
				specificDocument.OnGetRewardFindBack(oArg);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
			}
		}

		// Token: 0x0600DDB8 RID: 56760 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ItemFindBackArg oArg)
		{
		}
	}
}
