using System;

namespace XMainClient
{

	internal class Process_PtcG2C_DoodadItemSkillsNtf
	{

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
