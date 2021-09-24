using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_FetchAchivementReward
	{

		public static void OnReply(FetchAchiveArg oArg, FetchAchiveRes oRes)
		{
			bool flag = oRes.Result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.Result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.Result, "fece00");
				}
				else
				{
					XSingleton<XTutorialHelper>.singleton.GetReward = true;
				}
			}
		}

		public static void OnTimeout(FetchAchiveArg oArg)
		{
		}
	}
}
