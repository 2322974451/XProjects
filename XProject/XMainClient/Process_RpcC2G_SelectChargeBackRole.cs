using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001671 RID: 5745
	internal class Process_RpcC2G_SelectChargeBackRole
	{
		// Token: 0x0600EF14 RID: 61204 RVA: 0x0034ABA4 File Offset: 0x00348DA4
		public static void OnReply(SelectChargeBackRoleArg oArg, SelectChargeBackRoleRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XBackFlowDocument.Doc.OnGetSelectRoleReply();
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
			}
		}

		// Token: 0x0600EF15 RID: 61205 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(SelectChargeBackRoleArg oArg)
		{
		}
	}
}
