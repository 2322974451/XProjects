using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B5B RID: 2907
	internal class Process_RpcC2M_GuildAuctReqAll
	{
		// Token: 0x0600A8FA RID: 43258 RVA: 0x001E1468 File Offset: 0x001DF668
		public static void OnReply(GuildAuctReqArg oArg, GuildAuctReqRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
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
					bool flag3 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
					}
					AuctionHouseDocument specificDocument = XDocuments.GetSpecificDocument<AuctionHouseDocument>(AuctionHouseDocument.uuID);
					specificDocument.OnServerReturn(oArg, oRes);
				}
			}
		}

		// Token: 0x0600A8FB RID: 43259 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GuildAuctReqArg oArg)
		{
		}
	}
}
