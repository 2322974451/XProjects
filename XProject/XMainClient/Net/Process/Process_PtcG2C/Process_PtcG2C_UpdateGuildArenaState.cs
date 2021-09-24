using System;

namespace XMainClient
{

	internal class Process_PtcG2C_UpdateGuildArenaState
	{

		public static void Process(PtcG2C_UpdateGuildArenaState roPtc)
		{
			XGuildArenaDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			specificDocument.OnUpdateGuildArenaState(roPtc.Data);
		}
	}
}
