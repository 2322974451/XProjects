using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_FetchMail
	{

		public static void OnReply(FetchMailArg oArg, FetchMailRes oRes)
		{
			bool flag = oRes == null;
			if (!flag)
			{
				XMailDocument specificDocument = XDocuments.GetSpecificDocument<XMailDocument>(XMailDocument.uuID);
				specificDocument.ResMailInfo(oRes);
			}
		}

		public static void OnTimeout(FetchMailArg oArg)
		{
		}
	}
}
