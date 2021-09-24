using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_GetDragonGuildShopRecord
	{

		public static void OnReply(GetDragonGuildShopRecordArg oArg, GetDragonGuildShopRecordRes oRes)
		{
			XDragonGuildDocument.Doc.OnGetShopRecordBack(oRes);
		}

		public static void OnTimeout(GetDragonGuildShopRecordArg oArg)
		{
		}
	}
}
