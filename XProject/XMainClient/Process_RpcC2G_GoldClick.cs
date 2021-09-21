using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B69 RID: 2921
	internal class Process_RpcC2G_GoldClick
	{
		// Token: 0x0600A91B RID: 43291 RVA: 0x001E1A24 File Offset: 0x001DFC24
		public static void OnReply(GoldClickArg oArg, GoldClickRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
				specificDocument.OnGetMoneyTreeInfo(oArg.type, oArg.count, oRes);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
		}

		// Token: 0x0600A91C RID: 43292 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GoldClickArg oArg)
		{
		}
	}
}
