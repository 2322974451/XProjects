using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020012E1 RID: 4833
	internal class Process_RpcC2M_TryFish
	{
		// Token: 0x0600E06B RID: 57451 RVA: 0x00335FF8 File Offset: 0x003341F8
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

		// Token: 0x0600E06C RID: 57452 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(TryFishArg oArg)
		{
		}
	}
}
