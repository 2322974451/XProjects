using System;

namespace XMainClient
{

	internal class Process_PtcG2C_GCFSynG2CNtf
	{

		public static void Process(PtcG2C_GCFSynG2CNtf roPtc)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.OnGCFSynG2CNtf(roPtc.Data);
		}
	}
}
