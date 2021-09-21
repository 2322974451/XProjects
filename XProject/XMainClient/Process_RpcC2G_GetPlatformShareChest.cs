using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020014CA RID: 5322
	internal class Process_RpcC2G_GetPlatformShareChest
	{
		// Token: 0x0600E832 RID: 59442 RVA: 0x00341080 File Offset: 0x0033F280
		public static void OnReply(GetPlatformShareChestArg oArg, GetPlatformShareChestRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
				else
				{
					DlgBase<RandomGiftView, RandomGiftBehaviour>.singleton.ReadyShareGift(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E833 RID: 59443 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetPlatformShareChestArg oArg)
		{
		}
	}
}
