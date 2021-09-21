using System;

namespace XMainClient
{
	// Token: 0x0200169B RID: 5787
	internal class Process_PtcM2C_MarriageNewPrivilegeNtf
	{
		// Token: 0x0600EFC4 RID: 61380 RVA: 0x0034BDE8 File Offset: 0x00349FE8
		public static void Process(PtcM2C_MarriageNewPrivilegeNtf roPtc)
		{
			XWeddingDocument specificDocument = XDocuments.GetSpecificDocument<XWeddingDocument>(XWeddingDocument.uuID);
			specificDocument.OnMarriageNewPrivilegeNtf(roPtc.Data.marriageLevel);
		}
	}
}
