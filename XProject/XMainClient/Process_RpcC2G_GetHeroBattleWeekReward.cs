using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200145A RID: 5210
	internal class Process_RpcC2G_GetHeroBattleWeekReward
	{
		// Token: 0x0600E671 RID: 58993 RVA: 0x0033E7CC File Offset: 0x0033C9CC
		public static void OnReply(GetHeroBattleWeekRewardArg oArg, GetHeroBattleWeekRewardRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
				else
				{
					XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
					specificDocument.OnGetRewardSuccess(oRes.getnextweekprize, oRes.weekprize);
				}
			}
		}

		// Token: 0x0600E672 RID: 58994 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetHeroBattleWeekRewardArg oArg)
		{
		}
	}
}
