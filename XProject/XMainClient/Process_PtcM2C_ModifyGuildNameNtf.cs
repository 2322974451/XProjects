using System;

namespace XMainClient
{
	// Token: 0x020014C2 RID: 5314
	internal class Process_PtcM2C_ModifyGuildNameNtf
	{
		// Token: 0x0600E811 RID: 59409 RVA: 0x00340DAC File Offset: 0x0033EFAC
		public static void Process(PtcM2C_ModifyGuildNameNtf roPtc)
		{
			XRenameDocument specificDocument = XDocuments.GetSpecificDocument<XRenameDocument>(XRenameDocument.uuID);
			specificDocument.NotifyGuildNewName(roPtc.Data.name);
		}
	}
}
