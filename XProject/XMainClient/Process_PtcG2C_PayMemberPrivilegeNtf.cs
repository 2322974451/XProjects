using System;

namespace XMainClient
{
	// Token: 0x02001372 RID: 4978
	internal class Process_PtcG2C_PayMemberPrivilegeNtf
	{
		// Token: 0x0600E2C1 RID: 58049 RVA: 0x00339878 File Offset: 0x00337A78
		public static void Process(PtcG2C_PayMemberPrivilegeNtf roPtc)
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			specificDocument.OnGetPayMemberPrivilege(roPtc.Data);
		}
	}
}
