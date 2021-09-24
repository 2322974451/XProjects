using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_GetLevelSealSelfGift
	{

		public static void OnReply(GetLevelSealSealGiftArg oArg, GetLevelSealSelfGiftRes oRes)
		{
			bool flag = oRes.errcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errcode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errcode, "fece00");
				}
				else
				{
					XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
					specificDocument.CurrentSelfCollectIndex++;
					specificDocument.RefreshSelfGift();
				}
			}
		}

		public static void OnTimeout(GetLevelSealSealGiftArg oArg)
		{
		}
	}
}
