using System;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class Process_PtcG2C_UpdateBuyGoldAndFatigueInfo
	{

		public static void Process(PtcG2C_UpdateBuyGoldAndFatigueInfo roPtc)
		{
			DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.UpdatePlayerBuyInfo(roPtc.Data);
			XPurchaseDocument specificDocument = XDocuments.GetSpecificDocument<XPurchaseDocument>(XPurchaseDocument.uuID);
			specificDocument.InitPurchaseInfo(roPtc.Data);
		}
	}
}
