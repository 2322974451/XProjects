using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020010FE RID: 4350
	internal class Process_PtcG2C_ReachDesignationNtf
	{
		// Token: 0x0600D8B6 RID: 55478 RVA: 0x00329F28 File Offset: 0x00328128
		public static void Process(PtcG2C_ReachDesignationNtf roPtc)
		{
			XDesignationDocument xdesignationDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XDesignationDocument.uuID) as XDesignationDocument;
			xdesignationDocument.OnReachDesignationNtf(roPtc);
		}
	}
}
