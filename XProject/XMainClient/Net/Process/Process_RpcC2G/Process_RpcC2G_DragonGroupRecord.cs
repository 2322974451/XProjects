using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_DragonGroupRecord
	{

		public static void OnReply(DragonGroupRecordC2S oArg, DragonGroupRecordS2C oRes)
		{
			XDragonPartnerDocument specificDocument = XDocuments.GetSpecificDocument<XDragonPartnerDocument>(XDragonPartnerDocument.uuID);
			specificDocument.ReceiveDragonGroupRecord(oArg, oRes);
		}

		public static void OnTimeout(DragonGroupRecordC2S oArg)
		{
		}
	}
}
