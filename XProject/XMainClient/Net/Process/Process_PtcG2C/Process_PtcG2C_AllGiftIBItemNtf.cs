using System;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class Process_PtcG2C_AllGiftIBItemNtf
	{

		public static void Process(PtcG2C_AllGiftIBItemNtf roPtc)
		{
			bool flag = roPtc.Data.gift != null;
			if (flag)
			{
				DlgBase<GiftClaimDlg, GiftClaimBehaviour>.singleton.HanderGift(roPtc.Data.gift);
			}
		}
	}
}
