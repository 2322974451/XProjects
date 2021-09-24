using System;

namespace XMainClient
{

	internal class Process_PtcG2C_GCFZhanLingNotify
	{

		public static void Process(PtcG2C_GCFZhanLingNotify roPtc)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.OnZhanLingNotify(roPtc.Data);
		}
	}
}
