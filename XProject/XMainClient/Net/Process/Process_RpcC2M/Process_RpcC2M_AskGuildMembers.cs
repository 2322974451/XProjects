using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_AskGuildMembers
	{

		public static void OnReply(GuildMemberArg oArg, GuildMemberRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
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
					bool flag3 = oArg.guildid == 0UL;
					if (flag3)
					{
						XGuildMemberDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMemberDocument>(XGuildMemberDocument.uuID);
						specificDocument.onGetMemberList(oRes);
					}
					else
					{
						XGuildViewDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildViewDocument>(XGuildViewDocument.uuID);
						specificDocument2.onGetMemberList(oRes);
					}
				}
			}
		}

		public static void OnTimeout(GuildMemberArg oArg)
		{
		}
	}
}
