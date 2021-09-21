using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001060 RID: 4192
	internal class Process_RpcC2G_AddTempAttr
	{
		// Token: 0x0600D63A RID: 54842 RVA: 0x00325CD4 File Offset: 0x00323ED4
		public static void OnReply(AddTempAttrArg oArg, AddTempAttrRes oRes)
		{
			bool flag = oRes.ErrorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oArg.type == 0U;
				if (flag2)
				{
					XWorldBossDocument specificDocument = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
					specificDocument.OnGetEncourage(oRes);
				}
				else
				{
					XGuildDragonDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
					specificDocument2.OnGetEncourage(oRes);
				}
			}
		}

		// Token: 0x0600D63B RID: 54843 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AddTempAttrArg oArg)
		{
		}
	}
}
