using System;

namespace XMainClient
{

	internal class Process_PtcG2C_ChangeNameCountNtf
	{

		public static void Process(PtcG2C_ChangeNameCountNtf roPtc)
		{
			XRenameDocument specificDocument = XDocuments.GetSpecificDocument<XRenameDocument>(XRenameDocument.uuID);
			specificDocument.SetPlayerRenameTimes(roPtc.Data.count);
		}
	}
}
