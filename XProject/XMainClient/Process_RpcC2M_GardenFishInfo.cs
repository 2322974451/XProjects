using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001338 RID: 4920
	internal class Process_RpcC2M_GardenFishInfo
	{
		// Token: 0x0600E1CF RID: 57807 RVA: 0x003381E4 File Offset: 0x003363E4
		public static void OnReply(GardenFishInfoArg oArg, GardenFishInfoRes oRes)
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
						specificDocument.SetLevelExpInfo(oRes.fish_level, oRes.experiences);
					}
				}
			}
		}

		// Token: 0x0600E1D0 RID: 57808 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GardenFishInfoArg oArg)
		{
		}
	}
}
