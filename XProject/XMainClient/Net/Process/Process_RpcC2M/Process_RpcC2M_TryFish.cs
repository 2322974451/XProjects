using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_TryFish
	{

		public static void OnReply(TryFishArg oArg, TryFishRes oRes)
		{
			XHomeFishingDocument specificDocument = XDocuments.GetSpecificDocument<XHomeFishingDocument>(XHomeFishingDocument.uuID);
			bool flag = oRes == null;
			if (flag)
			{
				specificDocument.ErrorLeaveFishing();
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					specificDocument.ErrorLeaveFishing();
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.result > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						specificDocument.ErrorLeaveFishing();
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
					else
					{
						specificDocument.OnFishingResultGet(oRes.item, oRes.fish_level, oRes.experiences);
					}
				}
			}
		}

		public static void OnTimeout(TryFishArg oArg)
		{
		}
	}
}
