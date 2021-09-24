using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_FetchChapterChest
	{

		public static void OnReply(FetchChapterChestArg oArg, FetchChapterChestRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<XStageProgress>.singleton.OnFetchChapterBoxSucc(oArg.chapterID, oArg.chestID);
				}
			}
		}

		public static void OnTimeout(FetchChapterChestArg oArg)
		{
		}
	}
}
