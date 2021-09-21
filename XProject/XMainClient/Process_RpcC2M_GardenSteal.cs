using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200133C RID: 4924
	internal class Process_RpcC2M_GardenSteal
	{
		// Token: 0x0600E1E1 RID: 57825 RVA: 0x00338400 File Offset: 0x00336600
		public static void OnReply(GardenStealArg oArg, GardenStealRes oRes)
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
					HomePlantDocument.Doc.OnHomeStealBack(oArg.farmland_id, oRes);
				}
			}
		}

		// Token: 0x0600E1E2 RID: 57826 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GardenStealArg oArg)
		{
		}
	}
}
