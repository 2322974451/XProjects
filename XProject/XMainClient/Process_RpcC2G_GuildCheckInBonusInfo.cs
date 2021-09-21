using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001111 RID: 4369
	internal class Process_RpcC2G_GuildCheckInBonusInfo
	{
		// Token: 0x0600D905 RID: 55557 RVA: 0x0032A5E0 File Offset: 0x003287E0
		public static void OnReply(GuildCheckInBonusInfoArg oArg, GuildCheckInBonusInfoRes oRes)
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
				specificDocument.OnGuildCheckInBonusInfo(oRes);
			}
		}

		// Token: 0x0600D906 RID: 55558 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildCheckInBonusInfoArg oArg)
		{
		}
	}
}
