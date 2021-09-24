using System;

namespace XMainClient
{

	internal class Process_PtcG2C_MobaHintNtf
	{

		public static void Process(PtcG2C_MobaHintNtf roPtc)
		{
			XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
			specificDocument.MobaHintNotify(roPtc.Data);
		}
	}
}
