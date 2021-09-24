using System;

namespace XMainClient
{

	internal class Process_PtcG2C_SynAtlasAttr
	{

		public static void Process(PtcG2C_SynAtlasAttr roPtc)
		{
			XCardCollectDocument specificDocument = XDocuments.GetSpecificDocument<XCardCollectDocument>(XCardCollectDocument.uuID);
			specificDocument.OnRefreshAttr(roPtc);
		}
	}
}
