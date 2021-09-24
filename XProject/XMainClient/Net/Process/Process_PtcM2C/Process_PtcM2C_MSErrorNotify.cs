using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcM2C_MSErrorNotify
	{

		public static void Process(PtcM2C_MSErrorNotify roPtc)
		{
			ErrorCode errorno = (ErrorCode)roPtc.Data.errorno;
			if (errorno != ErrorCode.ERR_VERSION_FAILED)
			{
				if (errorno != ErrorCode.ERR_TEAM_LEADER_NOTHELPER)
				{
					if (errorno != ErrorCode.ERR_AUCT_AUCTOVER)
					{
						bool istip = roPtc.Data.istip;
						if (istip)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip((ErrorCode)roPtc.Data.errorno, "fece00");
						}
						else
						{
							XSingleton<UiUtility>.singleton.ShowErrorCode((ErrorCode)roPtc.Data.errorno);
						}
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip((ErrorCode)roPtc.Data.errorno, "fece00");
						AuctionHouseDocument specificDocument = XDocuments.GetSpecificDocument<AuctionHouseDocument>(AuctionHouseDocument.uuID);
						specificDocument.QueryRefreshUI();
					}
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip((ErrorCode)roPtc.Data.errorno, "fece00");
				}
			}
		}
	}
}
