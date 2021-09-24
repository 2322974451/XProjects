using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_SetPreShow
	{

		public static void OnReply(SetPreShowArg oArg, SetPreShowRes oRes)
		{
			XPrerogativeDocument specificDocument = XDocuments.GetSpecificDocument<XPrerogativeDocument>(XPrerogativeDocument.uuID);
			specificDocument.ReceivePreCache(oArg, oRes);
		}

		public static void OnTimeout(SetPreShowArg oArg)
		{
		}
	}
}
