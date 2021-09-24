using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_ActivatePreShow
	{

		public static void OnReply(ActivatePreShowArg oArg, ActivatePreShowRes oRes)
		{
			XPrerogativeDocument specificDocument = XDocuments.GetSpecificDocument<XPrerogativeDocument>(XPrerogativeDocument.uuID);
			specificDocument.ReceiveActiveReply(oArg, oRes);
		}

		public static void OnTimeout(ActivatePreShowArg oArg)
		{
		}
	}
}
