using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012AA RID: 4778
	internal class Process_RpcC2M_GuildCheckinNew
	{
		// Token: 0x0600DF87 RID: 57223 RVA: 0x00334B7C File Offset: 0x00332D7C
		public static void OnReply(GuildCheckinArg oArg, GuildCheckinRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XGuildSignInDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSignInDocument>(XGuildSignInDocument.uuID);
					specificDocument.OnSignIn(oArg, oRes);
				}
			}
		}

		// Token: 0x0600DF88 RID: 57224 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildCheckinArg oArg)
		{
		}
	}
}
