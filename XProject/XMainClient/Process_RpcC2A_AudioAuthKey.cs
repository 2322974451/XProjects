using System;
using System.Text;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001432 RID: 5170
	internal class Process_RpcC2A_AudioAuthKey
	{
		// Token: 0x0600E5D0 RID: 58832 RVA: 0x0033D734 File Offset: 0x0033B934
		public static void OnReply(AudioAuthKeyArg oArg, AudioAuthKeyRes oRes)
		{
			bool flag = oRes == null;
			if (!flag)
			{
				bool flag2 = oRes.error == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XChatDocument.m_ApolloInited = true;
					XChatDocument.m_ApolloKey = Encoding.Default.GetBytes(oRes.szAuthKey);
					XChatDocument.m_ApolloIPtable[0] = (int)oRes.dwMainSvrUrl1;
					XChatDocument.m_ApolloIPtable[1] = (int)oRes.dwMainSvrUrl2;
					XChatDocument.m_ApolloIPtable[2] = (int)oRes.dwSlaveSvrUrl1;
					XChatDocument.m_ApolloIPtable[3] = (int)oRes.dwSlaveSvrUrl2;
					XSingleton<XChatApolloMgr>.singleton.InitApolloEngine();
				}
			}
		}

		// Token: 0x0600E5D1 RID: 58833 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AudioAuthKeyArg oArg)
		{
		}
	}
}
