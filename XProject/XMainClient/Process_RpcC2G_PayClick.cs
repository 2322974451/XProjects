using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x020011D7 RID: 4567
	internal class Process_RpcC2G_PayClick
	{
		// Token: 0x0600DC24 RID: 56356 RVA: 0x0032FEB0 File Offset: 0x0032E0B0
		public static void OnReply(PayClickArg oArg, PayClickRes oRes)
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			specificDocument.RefreshFirstClickTabRedpoint(oArg, oRes);
		}

		// Token: 0x0600DC25 RID: 56357 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(PayClickArg oArg)
		{
		}
	}
}
