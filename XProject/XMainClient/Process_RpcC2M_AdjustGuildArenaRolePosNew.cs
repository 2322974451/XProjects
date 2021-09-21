using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012C5 RID: 4805
	internal class Process_RpcC2M_AdjustGuildArenaRolePosNew
	{
		// Token: 0x0600DFF9 RID: 57337 RVA: 0x00335644 File Offset: 0x00333844
		public static void OnReply(AdjustGuildArenaRolePosArg oArg, AdjustGuildArenaRolePosRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errorCode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
			}
		}

		// Token: 0x0600DFFA RID: 57338 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AdjustGuildArenaRolePosArg oArg)
		{
		}
	}
}
