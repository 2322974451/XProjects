using System;

namespace XMainClient
{

	internal class Process_PtcG2C_TakeRandomTask
	{

		public static void Process(PtcG2C_TakeRandomTask roPtc)
		{
			XLevelDocument specificDocument = XDocuments.GetSpecificDocument<XLevelDocument>(XLevelDocument.uuID);
			specificDocument.OnTaskRandomTask(roPtc.Data.taskid);
		}
	}
}
