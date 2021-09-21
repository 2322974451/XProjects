using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020014D2 RID: 5330
	internal class Process_RpcC2M_ArenaStarRoleReq
	{
		// Token: 0x0600E855 RID: 59477 RVA: 0x0034132C File Offset: 0x0033F52C
		public static void OnReply(ArenaStarReqArg oArg, ArenaStarReqRes oRes)
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
					bool flag3 = oRes.errorcode == ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XHallFameDocument.Doc.OnGetStarRoleInfo(oArg, oRes);
					}
				}
			}
		}

		// Token: 0x0600E856 RID: 59478 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ArenaStarReqArg oArg)
		{
		}
	}
}
