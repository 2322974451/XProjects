using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020011F4 RID: 4596
	internal class Process_RpcC2M_MSGetFlowerRewardList
	{
		// Token: 0x0600DC97 RID: 56471 RVA: 0x0033094C File Offset: 0x0032EB4C
		public static void OnReply(NewGetFlowerRewardListArg oArg, NewGetFlowerRewardListRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.errorCode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XFlowerRankDocument specificDocument = XDocuments.GetSpecificDocument<XFlowerRankDocument>(XFlowerRankDocument.uuID);
					specificDocument.OnGetAwardList(oArg, oRes);
				}
			}
		}

		// Token: 0x0600DC98 RID: 56472 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(NewGetFlowerRewardListArg oArg)
		{
		}
	}
}
