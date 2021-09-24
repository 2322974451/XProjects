using System;

namespace XMainClient
{

	internal class Process_PtcG2C_SpActivityChangeNtf
	{

		public static void Process(PtcG2C_SpActivityChangeNtf roPtc)
		{
			XTempActivityDocument.Doc.UpdateActivityTaskState(roPtc.Data.actid, roPtc.Data.taskid, roPtc.Data.state, roPtc.Data.progress);
			XCarnivalDocument specificDocument = XDocuments.GetSpecificDocument<XCarnivalDocument>(XCarnivalDocument.uuID);
			specificDocument.OnSpActivityChange(roPtc.Data);
			WeekEndNestDocument.Doc.TaskChangePtc(roPtc.Data.actid, roPtc.Data.taskid);
		}
	}
}
