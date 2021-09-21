using System;

namespace XMainClient
{
	// Token: 0x020011BF RID: 4543
	internal class Process_PtcM2C_RoleStateNtfNew
	{
		// Token: 0x0600DBC2 RID: 56258 RVA: 0x0032F734 File Offset: 0x0032D934
		public static void Process(PtcM2C_RoleStateNtfNew roPtc)
		{
			XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
			specificDocument.QueryRoleStateRes(roPtc.Data);
		}
	}
}
