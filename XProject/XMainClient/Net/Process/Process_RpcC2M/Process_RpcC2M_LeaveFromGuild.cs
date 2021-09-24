using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_LeaveFromGuild
	{

		public static void OnReply(LeaveGuildArg oArg, LeaveGuildRes oRes)
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
						bool flag4 = player.Attributes.EntityID == oArg.roleID;
						bool flag5 = flag4;
						if (flag5)
						{
							XGuildHallDocument specificDocument = XDocuments.GetSpecificDocument<XGuildHallDocument>(XGuildHallDocument.uuID);
							specificDocument.OnExitGuild(oRes);
						}
						else
						{
							XGuildMemberDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildMemberDocument>(XGuildMemberDocument.uuID);
							specificDocument2.OnKickAss(oArg, oRes);
						}
					}
				}
			}
		}

		public static void OnTimeout(LeaveGuildArg oArg)
		{
		}
	}
}
