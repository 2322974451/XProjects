using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_QueryPowerPoint
	{

		public static void OnReply(QueryPowerPointArg oArg, QueryPowerPointRes oRes)
		{
			XFPStrengthenDocument specificDocument = XDocuments.GetSpecificDocument<XFPStrengthenDocument>(XFPStrengthenDocument.uuID);
			specificDocument.RefreshUi(oRes);
		}

		public static void OnTimeout(QueryPowerPointArg oArg)
		{
		}
	}
}
