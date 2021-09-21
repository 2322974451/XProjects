using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001322 RID: 4898
	internal class Process_RpcC2M_GardenBanquet
	{
		// Token: 0x0600E178 RID: 57720 RVA: 0x003379FC File Offset: 0x00335BFC
		public static void OnReply(GardenBanquetArg oArg, GardenBanquetRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
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
					bool flag3 = oRes.result == ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XHomeCookAndPartyDocument.Doc.CurBanquetID = oArg.banquet_id;
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
				}
			}
		}

		// Token: 0x0600E179 RID: 57721 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GardenBanquetArg oArg)
		{
		}
	}
}
