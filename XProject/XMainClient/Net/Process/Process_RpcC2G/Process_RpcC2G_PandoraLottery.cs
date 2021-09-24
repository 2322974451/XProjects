using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_PandoraLottery
	{

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

		public static void OnTimeout(PandoraLotteryArg oArg)
		{
		}
	}
}
