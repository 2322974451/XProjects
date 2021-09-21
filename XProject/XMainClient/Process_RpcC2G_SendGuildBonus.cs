using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001113 RID: 4371
	internal class Process_RpcC2G_SendGuildBonus
	{
		// Token: 0x0600D90E RID: 55566 RVA: 0x0032A6B8 File Offset: 0x003288B8
		public static void OnReply(SendGuildBonusArg oArg, SendGuildBonusRes oRes)
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
				specificDocument.OnSendGuildBonus(oRes);
			}
		}

		// Token: 0x0600D90F RID: 55567 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SendGuildBonusArg oArg)
		{
		}
	}
}
