using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001687 RID: 5767
	internal class Process_RpcC2M_CrossGvgOper
	{
		// Token: 0x0600EF6D RID: 61293 RVA: 0x0034B4E8 File Offset: 0x003496E8
		public static void OnReply(CrossGvgOperArg oArg, CrossGvgOperRes oRes)
		{
			XCrossGVGDocument specificDocument = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
			specificDocument.NotifyCrossGVGOper(oArg, oRes);
		}

		// Token: 0x0600EF6E RID: 61294 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(CrossGvgOperArg oArg)
		{
		}
	}
}
