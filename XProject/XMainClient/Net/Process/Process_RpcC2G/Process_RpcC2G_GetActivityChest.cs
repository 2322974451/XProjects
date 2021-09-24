using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetActivityChest
	{

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

		public static void OnTimeout(GetActivityChestArg oArg)
		{
		}
	}
}
