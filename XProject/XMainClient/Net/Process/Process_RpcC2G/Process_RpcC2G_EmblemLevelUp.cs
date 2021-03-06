using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_EmblemLevelUp
	{

		public static void OnReply(EmblemLevelUpArg oArg, EmblemLevelUpRes oRes)
		{
			bool flag = oRes.ErrorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
		}

		public static void OnTimeout(EmblemLevelUpArg oArg)
		{
		}
	}
}
