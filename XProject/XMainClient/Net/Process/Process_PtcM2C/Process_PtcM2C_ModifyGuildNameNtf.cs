using System;

namespace XMainClient
{

	internal class Process_PtcM2C_ModifyGuildNameNtf
	{

		public static void Process(PtcM2C_ModifyGuildNameNtf roPtc)
		{
			XRenameDocument specificDocument = XDocuments.GetSpecificDocument<XRenameDocument>(XRenameDocument.uuID);
			specificDocument.NotifyGuildNewName(roPtc.Data.name);
		}
	}
}
