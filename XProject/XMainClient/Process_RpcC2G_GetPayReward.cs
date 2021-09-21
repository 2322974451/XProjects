using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020014A7 RID: 5287
	internal class Process_RpcC2G_GetPayReward
	{
		// Token: 0x0600E7A6 RID: 59302 RVA: 0x003404E0 File Offset: 0x0033E6E0
		public static void OnReply(GetPayRewardArg oArg, GetPayRewardRes oRes)
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
					XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
					specificDocument.OnGetLittleGiftBox(oArg, oRes);
				}
			}
		}

		// Token: 0x0600E7A7 RID: 59303 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetPayRewardArg oArg)
		{
		}
	}
}
