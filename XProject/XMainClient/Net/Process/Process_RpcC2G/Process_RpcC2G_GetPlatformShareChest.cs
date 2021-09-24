using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetPlatformShareChest
	{

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

		public static void OnTimeout(GetPlatformShareChestArg oArg)
		{
		}
	}
}
