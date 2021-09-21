using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001345 RID: 4933
	internal class Process_RpcC2M_OPenGardenFarmland
	{
		// Token: 0x0600E20A RID: 57866 RVA: 0x003387A4 File Offset: 0x003369A4
		public static void OnReply(OpenGardenFarmlandArg oArg, OpenGardenFarmlandRes oRes)
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
					HomePlantDocument.Doc.OnBreakNewFarmlandBack(oArg.farmland_id, oRes);
				}
			}
		}

		// Token: 0x0600E20B RID: 57867 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(OpenGardenFarmlandArg oArg)
		{
		}
	}
}
