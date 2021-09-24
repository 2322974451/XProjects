using System;

namespace XMainClient
{

	internal class Process_PtcG2C_synGuildInheritExp
	{

		public static void Process(PtcG2C_synGuildInheritExp roPtc)
		{
			XGuildInheritDocument specificDocument = XDocuments.GetSpecificDocument<XGuildInheritDocument>(XGuildInheritDocument.uuID);
			specificDocument.SynInheritExp(roPtc.Data);
		}
	}
}
