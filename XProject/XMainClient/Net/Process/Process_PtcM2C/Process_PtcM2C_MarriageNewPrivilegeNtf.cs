using System;

namespace XMainClient
{

	internal class Process_PtcM2C_MarriageNewPrivilegeNtf
	{

		public static void Process(PtcM2C_MarriageNewPrivilegeNtf roPtc)
		{
			XWeddingDocument specificDocument = XDocuments.GetSpecificDocument<XWeddingDocument>(XWeddingDocument.uuID);
			specificDocument.OnMarriageNewPrivilegeNtf(roPtc.Data.marriageLevel);
		}
	}
}
