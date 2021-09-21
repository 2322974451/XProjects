using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001525 RID: 5413
	internal class Process_RpcC2T_UpLoadAudioToGate
	{
		// Token: 0x0600E9AD RID: 59821 RVA: 0x003430D0 File Offset: 0x003412D0
		public static void OnReply(UpLoadAudioReq oArg, UpLoadAudioRes oRes)
		{
			bool flag = oRes == null;
			if (!flag)
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.result == ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						bool flag4 = oArg.srctype == 0U;
						if (flag4)
						{
							XSingleton<XChatIFlyMgr>.singleton.UpLoadMp3Res(oRes);
						}
						else
						{
							bool flag5 = oArg.srctype == 1U;
							if (flag5)
							{
								XSingleton<XChatApolloMgr>.singleton.UpLoadAudioRes(oRes);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600E9AE RID: 59822 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(UpLoadAudioReq oArg)
		{
		}
	}
}
