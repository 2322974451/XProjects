using System;

namespace XMainClient
{

	internal class Process_PtcG2C_UpdateTaskStatus
	{

		public static void Process(PtcG2C_UpdateTaskStatus roPtc)
		{
			XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
			specificDocument.OnTaskStatusUpdate(roPtc.Data);
		}
	}
}
