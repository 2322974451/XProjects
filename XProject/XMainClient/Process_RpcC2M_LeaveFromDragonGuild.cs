using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001631 RID: 5681
	internal class Process_RpcC2M_LeaveFromDragonGuild
	{
		// Token: 0x0600EE03 RID: 60931 RVA: 0x003492C8 File Offset: 0x003474C8
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

		// Token: 0x0600EE04 RID: 60932 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(LeaveDragonGuildArg oArg)
		{
		}
	}
}
