using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GuildGoblinInfo
	{

		public static void OnReply(GuildGoblinInfoArg oArg, GuildGoblinInfoRes oRes)
		{
			bool flag = oRes.errorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorCode == ErrorCode.ERR_SUCCESS;
				if (!flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorCode, "fece00");
				}
			}
		}

		public static void OnTimeout(GuildGoblinInfoArg oArg)
		{
		}
	}
}
