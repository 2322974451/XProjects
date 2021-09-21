using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200122C RID: 4652
	internal class Process_RpcC2M_CreateOrEnterGuild
	{
		// Token: 0x0600DD7C RID: 56700 RVA: 0x00331EB0 File Offset: 0x003300B0
		public static void OnReply(CreateOrJoinGuild oArg, CreateOrJoinGuildRes oRes)
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
					XGuildListDocument specificDocument = XDocuments.GetSpecificDocument<XGuildListDocument>(XGuildListDocument.uuID);
					bool iscreate = oArg.iscreate;
					if (iscreate)
					{
						specificDocument.OnCreateGuild(oArg, oRes);
					}
					else
					{
						specificDocument.OnApplyGuild(oArg, oRes);
					}
				}
			}
		}

		// Token: 0x0600DD7D RID: 56701 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(CreateOrJoinGuild oArg)
		{
		}
	}
}
