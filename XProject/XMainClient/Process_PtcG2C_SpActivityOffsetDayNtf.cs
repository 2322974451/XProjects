using System;

namespace XMainClient
{
	// Token: 0x0200131C RID: 4892
	internal class Process_PtcG2C_SpActivityOffsetDayNtf
	{
		// Token: 0x0600E15E RID: 57694 RVA: 0x003376DC File Offset: 0x003358DC
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
