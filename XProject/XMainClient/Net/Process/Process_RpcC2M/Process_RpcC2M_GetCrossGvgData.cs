using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_GetCrossGvgData
	{

		public static void OnReply(GetCrossGvgDataArg oArg, GetCrossGvgDataRes oRes)
		{
			XCrossGVGDocument specificDocument = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
			specificDocument.ReceiveCrossGVGData(oRes);
		}

		public static void OnTimeout(GetCrossGvgDataArg oArg)
		{
		}
	}
}
