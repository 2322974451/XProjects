using System;

namespace XMainClient
{
	// Token: 0x0200145D RID: 5213
	internal class Process_PtcG2C_IBShopHasBuyNtf
	{
		// Token: 0x0600E67B RID: 59003 RVA: 0x0033E9AC File Offset: 0x0033CBAC
		public static void Process(PtcG2C_IBShopHasBuyNtf roPtc)
		{
			XGameMallDocument specificDocument = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			specificDocument.UpdateItemBuyCnt(roPtc.Data.goodsid, roPtc.Data.count);
		}
	}
}
