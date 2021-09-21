using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EC8 RID: 3784
	internal class Process_RpcC2G_GetActivityChest
	{
		// Token: 0x0600C8BD RID: 51389 RVA: 0x002CF00C File Offset: 0x002CD20C
		public static void OnReply(GetActivityChestArg oArg, GetActivityChestRes oRes)
		{
			bool flag = oRes.ErrorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
				}
				else
				{
					XDailyActivitiesDocument specificDocument = XDocuments.GetSpecificDocument<XDailyActivitiesDocument>(XDailyActivitiesDocument.uuID);
					specificDocument.OnFetchChest(oArg.ChestIndex, oRes.ChestGetInfo, oRes.ItemId, oRes.ItemCount);
				}
			}
		}

		// Token: 0x0600C8BE RID: 51390 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetActivityChestArg oArg)
		{
		}
	}
}
