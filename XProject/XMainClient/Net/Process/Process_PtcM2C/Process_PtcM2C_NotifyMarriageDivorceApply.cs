using System;

namespace XMainClient
{

	internal class Process_PtcM2C_NotifyMarriageDivorceApply
	{

		public static void Process(PtcM2C_NotifyMarriageDivorceApply roPtc)
		{
			XWeddingDocument.Doc.OnGetMarriageDivorceNotify(roPtc);
		}
	}
}
