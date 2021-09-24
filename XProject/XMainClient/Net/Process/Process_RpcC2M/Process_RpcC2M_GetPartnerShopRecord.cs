using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_GetPartnerShopRecord
	{

		public static void OnReply(GetPartnerShopRecordArg oArg, GetPartnerShopRecordRes oRes)
		{
			XPartnerDocument.Doc.OnGetShopRecordBack(oRes);
		}

		public static void OnTimeout(GetPartnerShopRecordArg oArg)
		{
		}
	}
}
