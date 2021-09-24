using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_DEProgressReq
	{

		public static void OnReply(DEProgressArg oArg, DEProgressRes oRes)
		{
			XDragonCrusadeDocument specificDocument = XDocuments.GetSpecificDocument<XDragonCrusadeDocument>(XDragonCrusadeDocument.uuID);
			specificDocument.OnDEProgressReq(oRes);
			XActivityDocument.Doc.OnGetDayCount();
		}

		public static void OnTimeout(DEProgressArg oArg)
		{
		}
	}
}
