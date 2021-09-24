using System;

namespace XMainClient
{

	internal class Process_PtcG2C_PayMemberPrivilegeNtf
	{

		public static void Process(PtcG2C_PayMemberPrivilegeNtf roPtc)
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			specificDocument.OnGetPayMemberPrivilege(roPtc.Data);
		}
	}
}
