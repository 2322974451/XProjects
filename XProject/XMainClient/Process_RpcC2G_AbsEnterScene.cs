using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001505 RID: 5381
	internal class Process_RpcC2G_AbsEnterScene
	{
		// Token: 0x0600E92B RID: 59691 RVA: 0x00342470 File Offset: 0x00340670
		public static void OnReply(AbsEnterSceneArg oArg, AbsEnterSceneRes oRes)
		{
			bool flag = oRes.error == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.error > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
				}
			}
		}

		// Token: 0x0600E92C RID: 59692 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AbsEnterSceneArg oArg)
		{
		}
	}
}
