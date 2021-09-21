using System;

namespace XMainClient
{
	// Token: 0x0200164F RID: 5711
	internal class Process_PtcG2C_DoodadItemSkillsNtf
	{
		// Token: 0x0600EE87 RID: 61063 RVA: 0x00349E68 File Offset: 0x00348068
		public static void Process(PtcG2C_DoodadItemSkillsNtf roPtc)
		{
			bool flag = XRaceDocument.Doc.RaceHandler != null;
			if (flag)
			{
				XRaceDocument.Doc.RaceHandler.RefreshDoodad(roPtc.Data);
			}
		}
	}
}
