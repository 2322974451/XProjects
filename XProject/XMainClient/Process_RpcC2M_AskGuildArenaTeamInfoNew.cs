using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012C3 RID: 4803
	internal class Process_RpcC2M_AskGuildArenaTeamInfoNew
	{
		// Token: 0x0600DFF0 RID: 57328 RVA: 0x0033556C File Offset: 0x0033376C
		public static void OnReply(AskGuildArenaTeamInfoArg oArg, AskGuildArenaTeamInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
			}
		}

		// Token: 0x0600DFF1 RID: 57329 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AskGuildArenaTeamInfoArg oArg)
		{
		}
	}
}
