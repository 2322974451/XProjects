using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200143C RID: 5180
	internal class Process_RpcC2G_QueryClientIp
	{
		// Token: 0x0600E5F9 RID: 58873 RVA: 0x0033DB20 File Offset: 0x0033BD20
		public static void OnReply(QueryClientIpArg oArg, QueryClientIpRes oRes)
		{
			XChatDocument.m_ClientIP = oRes.ip;
			RpcC2A_AudioAuthKey rpcC2A_AudioAuthKey = new RpcC2A_AudioAuthKey();
			rpcC2A_AudioAuthKey.oArg.ip = oRes.ip;
			rpcC2A_AudioAuthKey.oArg.open_id = "63662733";
			XSingleton<XClientNetwork>.singleton.Send(rpcC2A_AudioAuthKey);
		}

		// Token: 0x0600E5FA RID: 58874 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(QueryClientIpArg oArg)
		{
		}
	}
}
