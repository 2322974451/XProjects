using System;

namespace XMainClient
{

	internal class Process_PtcG2C_BFFightTimeNtf
	{

		public static void Process(PtcG2C_BFFightTimeNtf roPtc)
		{
			XBattleFieldBattleDocument.Doc.SetTime(roPtc);
		}
	}
}
