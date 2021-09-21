using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001076 RID: 4214
	internal class Process_RpcC2G_FetchChapterChest
	{
		// Token: 0x0600D694 RID: 54932 RVA: 0x003264F0 File Offset: 0x003246F0
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

		// Token: 0x0600D695 RID: 54933 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(FetchChapterChestArg oArg)
		{
		}
	}
}
