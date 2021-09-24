using System;

namespace XMainClient
{

	internal class Process_PtcG2C_PkRoleInfoNtf
	{

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
