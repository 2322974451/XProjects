using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001134 RID: 4404
	internal class Process_RpcC2A_GetAudioListReq
	{
		// Token: 0x0600D995 RID: 55701 RVA: 0x0032B47C File Offset: 0x0032967C
		public static void OnReply(GetAudioListReq oArg, GetAudioListRes oRes)
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
						XSingleton<XChatIFlyMgr>.singleton.DownloadMp3Res(oRes);
					}
					else
					{
						XSingleton<XChatIFlyMgr>.singleton.DownLoadMp3Error();
					}
				}
			}
		}

		// Token: 0x0600D996 RID: 55702 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetAudioListReq oArg)
		{
		}
	}
}
