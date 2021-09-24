using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_AskGuildBriefInfo
	{

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

		public static void OnTimeout(GuildBriefArg oArg)
		{
		}
	}
}
