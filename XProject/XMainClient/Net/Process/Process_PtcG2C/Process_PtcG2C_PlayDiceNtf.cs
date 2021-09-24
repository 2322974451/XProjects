using System;

namespace XMainClient
{

	internal class Process_PtcG2C_PlayDiceNtf
	{

		public static void Process(PtcG2C_PlayDiceNtf roPtc)
		{
			XSuperRiskDocument.Doc.PlayDiceNtfBack(roPtc);
		}
	}
}
