using System;

namespace XMainClient
{

	internal class Process_PtcG2C_SpActivityOffsetDayNtf
	{

		public static void Process(PtcG2C_SpActivityOffsetDayNtf roPtc)
		{
			XTempActivityDocument.Doc.InitOffsetDayInfos(roPtc.Data);
			for (int i = 0; i < roPtc.Data.actid.Count; i++)
			{
				bool flag = roPtc.Data.actid[i] == 1U;
				if (flag)
				{
					XCarnivalDocument specificDocument = XDocuments.GetSpecificDocument<XCarnivalDocument>(XCarnivalDocument.uuID);
					specificDocument.RespInfo(roPtc.Data.offsetday[i]);
				}
			}
		}
	}
}
