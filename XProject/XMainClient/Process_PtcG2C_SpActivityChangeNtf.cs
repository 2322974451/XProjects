using System;

namespace XMainClient
{
	// Token: 0x0200131A RID: 4890
	internal class Process_PtcG2C_SpActivityChangeNtf
	{
		// Token: 0x0600E157 RID: 57687 RVA: 0x00337608 File Offset: 0x00335808
		public static void Process(PtcG2C_SpActivityChangeNtf roPtc)
		{
			XTempActivityDocument.Doc.UpdateActivityTaskState(roPtc.Data.actid, roPtc.Data.taskid, roPtc.Data.state, roPtc.Data.progress);
			XCarnivalDocument specificDocument = XDocuments.GetSpecificDocument<XCarnivalDocument>(XCarnivalDocument.uuID);
			specificDocument.OnSpActivityChange(roPtc.Data);
			WeekEndNestDocument.Doc.TaskChangePtc(roPtc.Data.actid, roPtc.Data.taskid);
		}
	}
}
