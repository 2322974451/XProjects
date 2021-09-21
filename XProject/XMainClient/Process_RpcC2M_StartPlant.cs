using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012DB RID: 4827
	internal class Process_RpcC2M_StartPlant
	{
		// Token: 0x0600E050 RID: 57424 RVA: 0x00335D38 File Offset: 0x00333F38
		public static void OnReply(StartPlantArg oArg, StartPlantRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					HomePlantDocument.Doc.OnStartPlantBack(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E051 RID: 57425 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(StartPlantArg oArg)
		{
		}
	}
}
