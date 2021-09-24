using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_LeaveFromDragonGuild
	{

		public static void OnReply(LeaveDragonGuildArg oArg, LeaveDragonGuildRes oRes)
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
					XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
					bool flag3 = player == null;
					if (!flag3)
					{
						bool flag4 = player.Attributes.EntityID == oArg.roleid;
						bool flag5 = flag4;
						if (flag5)
						{
							XDragonGuildDocument.Doc.OnLeaveDragonGuild(oRes);
						}
						else
						{
							XDragonGuildDocument.Doc.OnKickAss(oArg, oRes);
						}
					}
				}
			}
		}

		public static void OnTimeout(LeaveDragonGuildArg oArg)
		{
		}
	}
}
