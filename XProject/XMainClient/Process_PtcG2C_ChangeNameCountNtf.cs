using System;

namespace XMainClient
{
	// Token: 0x02000B6E RID: 2926
	internal class Process_PtcG2C_ChangeNameCountNtf
	{
		// Token: 0x0600A928 RID: 43304 RVA: 0x001E1BE8 File Offset: 0x001DFDE8
		public static void Process(PtcG2C_ChangeNameCountNtf roPtc)
		{
			XRenameDocument specificDocument = XDocuments.GetSpecificDocument<XRenameDocument>(XRenameDocument.uuID);
			specificDocument.SetPlayerRenameTimes(roPtc.Data.count);
		}
	}
}
