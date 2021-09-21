using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001238 RID: 4664
	internal class Process_RpcC2G_ItemFindBackInfo
	{
		// Token: 0x0600DDAE RID: 56750 RVA: 0x00332350 File Offset: 0x00330550
		public static void OnReply(ItemFindBackInfoArg oArg, ItemFindBackInfoRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
				specificDocument.OnGetRewardInfo(oRes);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
			}
		}

		// Token: 0x0600DDAF RID: 56751 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ItemFindBackInfoArg oArg)
		{
		}
	}
}
