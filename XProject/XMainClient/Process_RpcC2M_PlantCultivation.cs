using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012DD RID: 4829
	internal class Process_RpcC2M_PlantCultivation
	{
		// Token: 0x0600E059 RID: 57433 RVA: 0x00335E20 File Offset: 0x00334020
		public static void OnReply(PlantCultivationArg oArg, PlantCultivationRes oRes)
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
					HomePlantDocument.Doc.OnPlantCultivationBack(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E05A RID: 57434 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(PlantCultivationArg oArg)
		{
		}
	}
}
