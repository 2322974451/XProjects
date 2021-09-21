using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200115F RID: 4447
	internal class Process_RpcC2G_ChangeWatchRole
	{
		// Token: 0x0600DA4B RID: 55883 RVA: 0x0032D024 File Offset: 0x0032B224
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

		// Token: 0x0600DA4C RID: 55884 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ChangeWatchRoleArg oArg)
		{
		}
	}
}
