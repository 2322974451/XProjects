using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D93 RID: 3475
	internal class Process_RpcC2G_GetGuildBonusReward
	{
		// Token: 0x0600BD3C RID: 48444 RVA: 0x00273634 File Offset: 0x00271834
		public static void OnReply(GetGuildBonusRewardArg oArg, GetGuildBonusRewardResult oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XGuildRedPacketDocument specificDocument = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
				specificDocument.OnFetch(oArg, oRes);
			}
		}

		// Token: 0x0600BD3D RID: 48445 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetGuildBonusRewardArg oArg)
		{
		}
	}
}
