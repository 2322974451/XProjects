using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_CrossGvgOper
	{

		public static void OnReply(CrossGvgOperArg oArg, CrossGvgOperRes oRes)
		{
			XCrossGVGDocument specificDocument = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
			specificDocument.NotifyCrossGVGOper(oArg, oRes);
		}

		public static void OnTimeout(CrossGvgOperArg oArg)
		{
		}
	}
}
