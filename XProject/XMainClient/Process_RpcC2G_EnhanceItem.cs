using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000ECB RID: 3787
	internal class Process_RpcC2G_EnhanceItem
	{
		// Token: 0x0600C8C6 RID: 51398 RVA: 0x002CF338 File Offset: 0x002CD538
		public static void OnReply(EnhanceItemArg oArg, EnhanceItemRes oRes)
		{
			bool flag = oRes.ErrorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XEnhanceDocument specificDocument = XDocuments.GetSpecificDocument<XEnhanceDocument>(XEnhanceDocument.uuID);
				specificDocument.OnEnhanceBack(oRes);
				bool flag2 = oRes.ErrorCode == ErrorCode.ERR_ENHANCE_SUCCEED;
				if (flag2)
				{
					XSingleton<XTutorialHelper>.singleton.EnhanceItem = true;
				}
			}
		}

		// Token: 0x0600C8C7 RID: 51399 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(EnhanceItemArg oArg)
		{
		}
	}
}
