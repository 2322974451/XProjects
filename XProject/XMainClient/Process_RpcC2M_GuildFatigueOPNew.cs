using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012B6 RID: 4790
	internal class Process_RpcC2M_GuildFatigueOPNew
	{
		// Token: 0x0600DFB7 RID: 57271 RVA: 0x00334FFC File Offset: 0x003331FC
		public static void OnReply(GuildFatigueArg oArg, GuildFatigueRes oRes)
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
					XGuildMemberDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMemberDocument>(XGuildMemberDocument.uuID);
					specificDocument.OnOperateFatigue(oArg, oRes);
				}
			}
		}

		// Token: 0x0600DFB8 RID: 57272 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildFatigueArg oArg)
		{
		}
	}
}
