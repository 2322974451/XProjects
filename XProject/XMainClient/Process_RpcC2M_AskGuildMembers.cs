using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001267 RID: 4711
	internal class Process_RpcC2M_AskGuildMembers
	{
		// Token: 0x0600DE78 RID: 56952 RVA: 0x00333498 File Offset: 0x00331698
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

		// Token: 0x0600DE79 RID: 56953 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildMemberArg oArg)
		{
		}
	}
}
