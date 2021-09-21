using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020014BA RID: 5306
	internal class Process_RpcC2G_PayFriendItem
	{
		// Token: 0x0600E7F2 RID: 59378 RVA: 0x00340B40 File Offset: 0x0033ED40
		public static void OnReply(PayFriendItemArg oArg, PayFriendItemRes oRes)
		{
			bool flag = oRes.ret == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
				specificDocument.OnGetBuyGoodsOrder(oArg, oRes);
			}
		}

		// Token: 0x0600E7F3 RID: 59379 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(PayFriendItemArg oArg)
		{
		}
	}
}
