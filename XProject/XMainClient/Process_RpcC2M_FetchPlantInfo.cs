using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012D9 RID: 4825
	internal class Process_RpcC2M_FetchPlantInfo
	{
		// Token: 0x0600E047 RID: 57415 RVA: 0x00335C48 File Offset: 0x00333E48
		public static void OnReply(FetchPlantInfoArg oArg, FetchPlantInfoRes oRes)
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
					HomePlantDocument.Doc.OnFetchPlantInfoBack(oArg.farmland_id, oRes);
				}
			}
		}

		// Token: 0x0600E048 RID: 57416 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(FetchPlantInfoArg oArg)
		{
		}
	}
}
