using System;

namespace XMainClient
{

	internal class Process_PtcG2C_BattleFieldReliveNtf
	{

		public static void Process(PtcG2C_BattleFieldReliveNtf roPtc)
		{
			XBattleFieldBattleDocument.Doc.SetReviveTime(roPtc);
		}
	}
}
