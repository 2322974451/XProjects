using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001374 RID: 4980
	internal class Process_RpcC2M_QueryResWarRoleRank
	{
		// Token: 0x0600E2C9 RID: 58057 RVA: 0x00339920 File Offset: 0x00337B20
		public static void OnReply(ResWarRoleRankArg oArg, ResWarRoleRankRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildMineMainDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
				specificDocument.OnGetRankInfo(oRes);
			}
		}

		// Token: 0x0600E2CA RID: 58058 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ResWarRoleRankArg oArg)
		{
		}
	}
}
