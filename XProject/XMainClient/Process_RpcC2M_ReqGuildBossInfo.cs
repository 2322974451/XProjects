using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001263 RID: 4707
	internal class Process_RpcC2M_ReqGuildBossInfo
	{
		// Token: 0x0600DE66 RID: 56934 RVA: 0x003332F4 File Offset: 0x003314F4
		public static void OnReply(AskGuildBossInfoArg oArg, AskGuildBossInfoRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
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
					XGuildDragonDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
					specificDocument.OnGetGuildBossInfo(oRes);
				}
			}
		}

		// Token: 0x0600DE67 RID: 56935 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AskGuildBossInfoArg oArg)
		{
		}
	}
}
