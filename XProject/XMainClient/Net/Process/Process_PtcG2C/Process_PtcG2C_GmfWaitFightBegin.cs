using System;

namespace XMainClient
{

	internal class Process_PtcG2C_GmfWaitFightBegin
	{

		public static void Process(PtcG2C_GmfWaitFightBegin roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.OnWaitFightBegin(roPtc.Data);
		}
	}
}
