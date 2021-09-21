using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001509 RID: 5385
	internal class Process_RpcC2G_ReplyPartyExchangeItemOpt
	{
		// Token: 0x0600E93B RID: 59707 RVA: 0x0034261C File Offset: 0x0034081C
		public static void OnReply(ReplyPartyExchangeItemOptArg oArg, ReplyPartyExchangeItemOptRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
				else
				{
					XRequestDocument specificDocument = XDocuments.GetSpecificDocument<XRequestDocument>(XRequestDocument.uuID);
					bool flag3 = oArg.operate_type == 3U;
					if (flag3)
					{
						DlgBase<RequestDlg, RequestBehaviour>.singleton.SetVisibleWithAnimation(false, null);
					}
					bool flag4 = oArg.operate_type == 2U;
					if (flag4)
					{
						specificDocument.RemoveList(true, 0UL);
					}
					else
					{
						specificDocument.RemoveList(false, oArg.lauch_role_id);
					}
				}
			}
		}

		// Token: 0x0600E93C RID: 59708 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(ReplyPartyExchangeItemOptArg oArg)
		{
		}
	}
}
