using System;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x0200105D RID: 4189
	internal class Process_PtcG2C_UpdateBuyGoldAndFatigueInfo
	{
		// Token: 0x0600D62D RID: 54829 RVA: 0x00325C00 File Offset: 0x00323E00
		public static void Process(PtcG2C_UpdateBuyGoldAndFatigueInfo roPtc)
		{
			DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.UpdatePlayerBuyInfo(roPtc.Data);
			XPurchaseDocument specificDocument = XDocuments.GetSpecificDocument<XPurchaseDocument>(XPurchaseDocument.uuID);
			specificDocument.InitPurchaseInfo(roPtc.Data);
		}
	}
}
