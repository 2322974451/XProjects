using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001419 RID: 5145
	internal class Process_RpcC2G_PandoraLottery
	{
		// Token: 0x0600E56D RID: 58733 RVA: 0x0033CF3C File Offset: 0x0033B13C
		public static void OnReply(PandoraLotteryArg oArg, PandoraLotteryRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				ErrorCode errorcode = oRes.errorcode;
				if (errorcode != ErrorCode.ERR_SUCCESS)
				{
					if (errorcode != ErrorCode.ERR_PANDORA_LACKOF_FIRE)
					{
						if (errorcode != ErrorCode.ERR_PANDORA_LACKOF_HEART)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
						}
						else
						{
							PandoraDocument specificDocument = XDocuments.GetSpecificDocument<PandoraDocument>(PandoraDocument.uuID);
							XSingleton<UiUtility>.singleton.ShowItemAccess((int)specificDocument.PandoraData.PandoraID, null);
						}
					}
					else
					{
						PandoraDocument specificDocument2 = XDocuments.GetSpecificDocument<PandoraDocument>(PandoraDocument.uuID);
						XSingleton<UiUtility>.singleton.ShowItemAccess((int)specificDocument2.PandoraData.FireID, null);
					}
				}
				else
				{
					PandoraDocument specificDocument3 = XDocuments.GetSpecificDocument<PandoraDocument>(PandoraDocument.uuID);
					specificDocument3.GetPandoraLotteryResult(oRes.items);
					XShowGetItemDocument specificDocument4 = XDocuments.GetSpecificDocument<XShowGetItemDocument>(XShowGetItemDocument.uuID);
					specificDocument4.ClearItemQueue();
				}
			}
		}

		// Token: 0x0600E56E RID: 58734 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(PandoraLotteryArg oArg)
		{
		}
	}
}
