using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020010F2 RID: 4338
	internal class Process_PtcG2C_CoverDesignationNtf
	{
		// Token: 0x0600D884 RID: 55428 RVA: 0x00329B00 File Offset: 0x00327D00
		public static void Process(PtcG2C_CoverDesignationNtf roPtc)
		{
			XDesignationDocument xdesignationDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XDesignationDocument.uuID) as XDesignationDocument;
			xdesignationDocument.SetCoverDesignationID(roPtc.Data.designationID, roPtc.Data.desname);
		}
	}
}
