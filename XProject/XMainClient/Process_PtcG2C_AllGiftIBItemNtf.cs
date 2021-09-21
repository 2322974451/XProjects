using System;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x020014BC RID: 5308
	internal class Process_PtcG2C_AllGiftIBItemNtf
	{
		// Token: 0x0600E7FA RID: 59386 RVA: 0x00340BE8 File Offset: 0x0033EDE8
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
