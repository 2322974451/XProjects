using System;

namespace XMainClient
{

	internal class Process_PtcG2C_GmfWaitOtherLoad
	{

		public static void Process(PtcG2C_GmfWaitOtherLoad roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnWaitOtherLoad(roPtc.Data);
		}
	}
}
