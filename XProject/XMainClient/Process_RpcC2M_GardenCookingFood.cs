using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012E5 RID: 4837
	internal class Process_RpcC2M_GardenCookingFood
	{
		// Token: 0x0600E07D RID: 57469 RVA: 0x0033621C File Offset: 0x0033441C
		public static void OnReply(GardenCookingFoodArg oArg, GardenCookingFoodRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
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
					bool flag3 = oRes.result == ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						HomeMainDocument.Doc.RefreshCookingInfo(oArg.food_id, oRes);
						XHomeCookAndPartyDocument.Doc.CookingFoodSuccess();
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
				}
			}
		}

		// Token: 0x0600E07E RID: 57470 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GardenCookingFoodArg oArg)
		{
		}
	}
}
