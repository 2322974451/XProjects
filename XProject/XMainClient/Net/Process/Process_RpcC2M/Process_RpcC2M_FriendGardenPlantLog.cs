using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_FriendGardenPlantLog
	{

		public static void OnReply(FriendGardenPlantLogArg oArg, FriendGardenPlantLogRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					HomeMainDocument.Doc.OnGetPlantFriendList(oRes);
				}
			}
		}

		public static void OnTimeout(FriendGardenPlantLogArg oArg)
		{
		}
	}
}
