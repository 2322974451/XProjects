using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200152E RID: 5422
	internal class Process_RpcC2M_GetFlowerActivityReward
	{
		// Token: 0x0600E9D4 RID: 59860 RVA: 0x00343490 File Offset: 0x00341690
		public static void OnReply(GetFlowerActivityRewardArg oArg, GetFlowerActivityRewardRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XFlowerRankDocument specificDocument = XDocuments.GetSpecificDocument<XFlowerRankDocument>(XFlowerRankDocument.uuID);
					specificDocument.OnGetFlowerActivityReward(oRes);
				}
			}
		}

		// Token: 0x0600E9D5 RID: 59861 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetFlowerActivityRewardArg oArg)
		{
		}
	}
}
