using System;

namespace XMainClient
{

	internal class Process_PtcM2C_RoleStateNtfNew
	{

		public static void Process(PtcM2C_RoleStateNtfNew roPtc)
		{
			XFriendsDocument specificDocument = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
			specificDocument.QueryRoleStateRes(roPtc.Data);
		}
	}
}
