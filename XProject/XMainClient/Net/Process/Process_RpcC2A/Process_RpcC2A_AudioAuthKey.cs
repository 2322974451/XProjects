using System;
using System.Text;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2A_AudioAuthKey
	{

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

		public static void OnTimeout(AudioAuthKeyArg oArg)
		{
		}
	}
}
