using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200132E RID: 4910
	internal class Process_RpcC2G_GetLevelSealSelfGift
	{
		// Token: 0x0600E1A6 RID: 57766 RVA: 0x00337E00 File Offset: 0x00336000
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

		// Token: 0x0600E1A7 RID: 57767 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetLevelSealSealGiftArg oArg)
		{
		}
	}
}
