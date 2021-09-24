using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2A_GetAudioListReq
	{

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

		public static void OnTimeout(GetAudioListReq oArg)
		{
		}
	}
}
