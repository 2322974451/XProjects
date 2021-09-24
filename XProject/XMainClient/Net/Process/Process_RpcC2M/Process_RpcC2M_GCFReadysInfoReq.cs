using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_GCFReadysInfoReq
	{

		public static void OnReply(GCFReadyInfoArg oArg, GCFReadyInfoRes oRes)
		{
			bool flag = oRes == null;
			if (!flag)
			{
				XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
				specificDocument.RespGCFReadysInfo(oRes);
			}
		}

		public static void OnTimeout(GCFReadyInfoArg oArg)
		{
		}
	}
}
