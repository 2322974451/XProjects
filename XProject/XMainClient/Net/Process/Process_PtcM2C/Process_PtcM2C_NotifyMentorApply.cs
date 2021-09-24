using System;

namespace XMainClient
{

	internal class Process_PtcM2C_NotifyMentorApply
	{

		public static void Process(PtcM2C_NotifyMentorApply roPtc)
		{
			XMentorshipDocument.Doc.OnGetMentorshipNotify(roPtc);
		}
	}
}
