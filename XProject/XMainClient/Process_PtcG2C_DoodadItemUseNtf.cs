using System;

namespace XMainClient
{
	// Token: 0x02001441 RID: 5185
	internal class Process_PtcG2C_DoodadItemUseNtf
	{
		// Token: 0x0600E60F RID: 58895 RVA: 0x0033DD40 File Offset: 0x0033BF40
		public static void Process(PtcG2C_DoodadItemUseNtf roPtc)
		{
			XRaceDocument.Doc.AddInfo(roPtc.Data);
		}
	}
}
