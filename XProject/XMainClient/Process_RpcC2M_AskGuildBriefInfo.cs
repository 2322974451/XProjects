using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200122A RID: 4650
	internal class Process_RpcC2M_AskGuildBriefInfo
	{
		// Token: 0x0600DD73 RID: 56691 RVA: 0x00331D84 File Offset: 0x0032FF84
		public static void OnReply(GuildBriefArg oArg, GuildBriefRes oRes)
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
						XGuildHallDocument specificDocument = XDocuments.GetSpecificDocument<XGuildHallDocument>(XGuildHallDocument.uuID);
						specificDocument.OnGuildBrief(oRes);
						XGuildApproveDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildApproveDocument>(XGuildApproveDocument.uuID);
						specificDocument2.OnGuildBrief(oRes);
					}
					else
					{
						XGuildViewDocument specificDocument3 = XDocuments.GetSpecificDocument<XGuildViewDocument>(XGuildViewDocument.uuID);
						specificDocument3.OnGuildBrief(oRes);
					}
				}
			}
		}

		// Token: 0x0600DD74 RID: 56692 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildBriefArg oArg)
		{
		}
	}
}
