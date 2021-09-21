using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020011C3 RID: 4547
	internal class Process_RpcC2M_GetWorldBossStateNew
	{
		// Token: 0x0600DBD3 RID: 56275 RVA: 0x0032F884 File Offset: 0x0032DA84
		public static void OnReply(GetWorldBossStateArg oArg, GetWorldBossStateRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oArg.type == 0U;
				if (flag2)
				{
					XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
					specificDocument.OnGetWorldBossLeftState(oRes);
				}
				else
				{
					XGuildDragonDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
					specificDocument2.OnGetWorldBossLeftState(oRes);
				}
			}
		}

		// Token: 0x0600DBD4 RID: 56276 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetWorldBossStateArg oArg)
		{
		}
	}
}
