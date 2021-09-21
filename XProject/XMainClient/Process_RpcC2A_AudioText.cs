using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001434 RID: 5172
	internal class Process_RpcC2A_AudioText
	{
		// Token: 0x0600E5D9 RID: 58841 RVA: 0x0033D838 File Offset: 0x0033BA38
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

		// Token: 0x0600E5DA RID: 58842 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AudioTextArg oArg)
		{
		}
	}
}
