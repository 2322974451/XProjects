using System;

namespace XMainClient
{

	internal class Process_PtcG2C_SynGuildInheritNumInfo
	{

		public static void Process(PtcG2C_SynGuildInheritNumInfo roPtc)
		{
			XGuildInheritDocument specificDocument = XDocuments.GetSpecificDocument<XGuildInheritDocument>(XGuildInheritDocument.uuID);
			specificDocument.SynInheritBaseInfo(roPtc.Data);
		}
	}
}
