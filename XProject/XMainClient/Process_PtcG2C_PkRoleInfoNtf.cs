using System;

namespace XMainClient
{
	// Token: 0x020010BB RID: 4283
	internal class Process_PtcG2C_PkRoleInfoNtf
	{
		// Token: 0x0600D7A8 RID: 55208 RVA: 0x0032872C File Offset: 0x0032692C
		public static void Process(PtcG2C_PkRoleInfoNtf roPtc)
		{
			XQualifyingDocument specificDocument = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
			bool flag = roPtc.Data.pkroleinfo.Count > 0;
			if (flag)
			{
				specificDocument.SetPkRoleInfo(roPtc.Data.pkroleinfo);
			}
		}
	}
}
