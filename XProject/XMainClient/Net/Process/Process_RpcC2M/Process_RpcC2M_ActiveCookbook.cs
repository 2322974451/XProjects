using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_ActiveCookbook
	{

		public static void OnReply(ActiveCookbookArg oArg, ActiveCookbookRes oRes)
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
						CookingFoodInfo.RowData cookInfoByCuisineID = XHomeCookAndPartyDocument.Doc.GetCookInfoByCuisineID(oRes.food_id);
						bool flag4 = cookInfoByCuisineID != null;
						if (flag4)
						{
							string label = XStringDefineProxy.GetString("CookMenuActiveSuccess") + "[00ff00]" + cookInfoByCuisineID.FoodName + "[-]";
							XSingleton<UiUtility>.singleton.ShowModalDialog(label, XStringDefineProxy.GetString("COMMON_OK"));
							XHomeCookAndPartyDocument.Doc.AddNewCookItem(oRes.food_id);
						}
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
				}
			}
		}

		public static void OnTimeout(ActiveCookbookArg oArg)
		{
		}
	}
}
