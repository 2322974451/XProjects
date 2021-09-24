using System;

namespace XMainClient
{

	internal class Process_PtcM2C_MarriageLevelValueNtf
	{

		public static void Process(PtcM2C_MarriageLevelValueNtf roPtc)
		{
			XWeddingDocument specificDocument = XDocuments.GetSpecificDocument<XWeddingDocument>(XWeddingDocument.uuID);
			specificDocument.OnMarriageLevelValueChangeNtf(roPtc.Data);
		}
	}
}
