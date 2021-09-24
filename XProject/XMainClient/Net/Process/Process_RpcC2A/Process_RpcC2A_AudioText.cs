using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2A_AudioText
	{

		public static void OnReply(AudioTextArg oArg, AudioTextRes oRes)
		{
			bool flag = oRes == null;
			if (!flag)
			{
				bool flag2 = oRes.error == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<XChatApolloMgr>.singleton.OnGotAudioText(oRes);
				}
				else
				{
					XSingleton<XDebug>.singleton.AddLog("Got file text error: ", oRes.error.ToString(), null, null, null, null, XDebugColor.XDebug_None);
					XSingleton<XChatApolloMgr>.singleton.OnGotAudioTextError(oRes);
				}
			}
		}

		public static void OnTimeout(AudioTextArg oArg)
		{
		}
	}
}
