using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_QueryClientIp
	{

		public static void OnReply(QueryClientIpArg oArg, QueryClientIpRes oRes)
		{
			XChatDocument.m_ClientIP = oRes.ip;
			RpcC2A_AudioAuthKey rpcC2A_AudioAuthKey = new RpcC2A_AudioAuthKey();
			rpcC2A_AudioAuthKey.oArg.ip = oRes.ip;
			rpcC2A_AudioAuthKey.oArg.open_id = "63662733";
			XSingleton<XClientNetwork>.singleton.Send(rpcC2A_AudioAuthKey);
		}

		public static void OnTimeout(QueryClientIpArg oArg)
		{
		}
	}
}
