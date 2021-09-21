using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012DF RID: 4831
	internal class Process_RpcC2M_PlantHarvest
	{
		// Token: 0x0600E062 RID: 57442 RVA: 0x00335F08 File Offset: 0x00334108
		public static void OnReply(PlantHarvestArg oArg, PlantHarvestRes oRes)
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
					HomePlantDocument.Doc.OnPlantHarvestBack(oArg.farmland_id, oRes);
				}
			}
		}

		// Token: 0x0600E063 RID: 57443 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(PlantHarvestArg oArg)
		{
		}
	}
}
