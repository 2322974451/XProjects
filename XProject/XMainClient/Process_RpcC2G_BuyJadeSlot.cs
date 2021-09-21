using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001046 RID: 4166
	internal class Process_RpcC2G_BuyJadeSlot
	{
		// Token: 0x0600D5CE RID: 54734 RVA: 0x00324FB0 File Offset: 0x003231B0
		public static void OnReply(BuyJadeSlotArg oArg, BuyJadeSlotRes oRes)
		{
			bool flag = oRes.ErrorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XJadeDocument specificDocument = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID);
				specificDocument.OnBuySlot(oRes);
			}
		}

		// Token: 0x0600D5CF RID: 54735 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(BuyJadeSlotArg oArg)
		{
		}
	}
}
