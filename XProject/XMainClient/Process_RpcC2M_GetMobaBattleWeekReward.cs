using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200156B RID: 5483
	internal class Process_RpcC2M_GetMobaBattleWeekReward
	{
		// Token: 0x0600EAC5 RID: 60101 RVA: 0x00344CBC File Offset: 0x00342EBC
		public static void OnReply(GetMobaBattleWeekRewardArg oArg, GetMobaBattleWeekRewardRes oRes)
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
					bool flag3 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
					}
					else
					{
						XMobaEntranceDocument specificDocument = XDocuments.GetSpecificDocument<XMobaEntranceDocument>(XMobaEntranceDocument.uuID);
						specificDocument.SetMobaNewReward(oArg, oRes);
					}
				}
			}
		}

		// Token: 0x0600EAC6 RID: 60102 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetMobaBattleWeekRewardArg oArg)
		{
		}
	}
}
