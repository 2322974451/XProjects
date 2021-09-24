using System;

namespace XMainClient
{

	internal class Process_PtcM2C_CustomBattleGMNotify
	{

		public static void Process(PtcM2C_CustomBattleGMNotify roPtc)
		{
			XCustomBattleDocument specificDocument = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
			specificDocument.IsCreateGM = roPtc.Data.isgmcreate;
		}
	}
}
