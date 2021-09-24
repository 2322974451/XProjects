using System;

namespace XMainClient
{

	internal class Process_PtcM2C_NotifyMarriageApply
	{

		public static void Process(PtcM2C_NotifyMarriageApply roPtc)
		{
			XWeddingDocument.Doc.OnGetMarriageApplyNotify(roPtc);
		}
	}
}
