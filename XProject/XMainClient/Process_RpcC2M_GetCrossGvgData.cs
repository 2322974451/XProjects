using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02001683 RID: 5763
	internal class Process_RpcC2M_GetCrossGvgData
	{
		// Token: 0x0600EF5D RID: 61277 RVA: 0x0034B3C4 File Offset: 0x003495C4
		public static void OnReply(GetCrossGvgDataArg oArg, GetCrossGvgDataRes oRes)
		{
			XCrossGVGDocument specificDocument = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
			specificDocument.ReceiveCrossGVGData(oRes);
		}

		// Token: 0x0600EF5E RID: 61278 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetCrossGvgDataArg oArg)
		{
		}
	}
}
