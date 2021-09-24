using System;

namespace XMainClient
{

	internal class Process_PtcG2C_AntiAddictionRemindNtf
	{

		public static void Process(PtcG2C_AntiAddictionRemindNtf roPtc)
		{
			AdditionRemindDocument specificDocument = XDocuments.GetSpecificDocument<AdditionRemindDocument>(AdditionRemindDocument.uuID);
			bool flag = specificDocument != null;
			if (flag)
			{
				specificDocument.OnRecieveAdditionTip(roPtc.Data.remindmsg);
			}
		}
	}
}
