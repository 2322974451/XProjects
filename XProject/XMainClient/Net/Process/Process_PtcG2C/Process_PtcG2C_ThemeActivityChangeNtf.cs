using System;

namespace XMainClient
{

	internal class Process_PtcG2C_ThemeActivityChangeNtf
	{

		public static void Process(PtcG2C_ThemeActivityChangeNtf roPtc)
		{
			XThemeActivityDocument.Doc.SetActivityChange(roPtc);
		}
	}
}
