using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200166F RID: 5743
	internal class Process_RpcC2G_GetNewZoneBenefit
	{
		// Token: 0x0600EF0B RID: 61195 RVA: 0x0034AAB0 File Offset: 0x00348CB0
		public static void OnReply(GetNewZoneBenefitArg oArg, GetNewZoneBenefitRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
				else
				{
					XBackFlowDocument.Doc.OnGetNewZoneBenefit(oRes);
				}
			}
		}

		// Token: 0x0600EF0C RID: 61196 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetNewZoneBenefitArg oArg)
		{
		}
	}
}
