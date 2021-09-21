using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200163B RID: 5691
	internal class Process_RpcC2M_GetDragonGuildTaskInfo
	{
		// Token: 0x0600EE2E RID: 60974 RVA: 0x0034968C File Offset: 0x0034788C
		public static void OnReply(GetDragonGuildTaskInfoArg oArg, GetDragonGuildTaskInfoRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				XDragonGuildTaskDocument specificDocument = XDocuments.GetSpecificDocument<XDragonGuildTaskDocument>(XDragonGuildTaskDocument.uuID);
				specificDocument.OnGetInfo(oRes);
			}
		}

		// Token: 0x0600EE2F RID: 60975 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetDragonGuildTaskInfoArg oArg)
		{
		}
	}
}
