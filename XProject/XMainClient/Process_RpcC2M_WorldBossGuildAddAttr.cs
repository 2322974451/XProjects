using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020014C4 RID: 5316
	internal class Process_RpcC2M_WorldBossGuildAddAttr
	{
		// Token: 0x0600E819 RID: 59417 RVA: 0x00340E58 File Offset: 0x0033F058
		public static void OnReply(WorldBossGuildAddAttrArg oArg, WorldBossGuildAddAttrRes oRes)
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
					XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
					specificDocument.OnGetEncourageTwo(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E81A RID: 59418 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(WorldBossGuildAddAttrArg oArg)
		{
		}
	}
}
