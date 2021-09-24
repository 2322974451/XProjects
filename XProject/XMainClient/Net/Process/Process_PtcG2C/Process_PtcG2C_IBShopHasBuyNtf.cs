using System;

namespace XMainClient
{

	internal class Process_PtcG2C_IBShopHasBuyNtf
	{

		public static void Process(PtcG2C_IBShopHasBuyNtf roPtc)
		{
			XGameMallDocument specificDocument = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			specificDocument.UpdateItemBuyCnt(roPtc.Data.goodsid, roPtc.Data.count);
		}
	}
}
