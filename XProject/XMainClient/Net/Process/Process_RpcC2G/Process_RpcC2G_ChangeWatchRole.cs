using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_ChangeWatchRole
	{

		public static void OnReply(ChangeWatchRoleArg oArg, ChangeWatchRoleRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.error == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<XEntityMgr>.singleton.Player.WatchIt(XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(oArg.roleID) as XRole);
				}
				else
				{
					XSingleton<XDebug>.singleton.AddLog("Change Spectator to ID: ", oArg.roleID.ToString(), "Failed.", null, null, null, XDebugColor.XDebug_None);
				}
			}
		}

		public static void OnTimeout(ChangeWatchRoleArg oArg)
		{
		}
	}
}
