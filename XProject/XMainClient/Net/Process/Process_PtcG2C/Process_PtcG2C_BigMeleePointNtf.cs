using System;

namespace XMainClient
{

	internal class Process_PtcG2C_BigMeleePointNtf
	{

		public static void Process(PtcG2C_BigMeleePointNtf roPtc)
		{
			bool flag = XBigMeleeBattleDocument.Doc.battleHandler != null;
			if (flag)
			{
				XBigMeleeBattleDocument.Doc.battleHandler.SetGetPointAnimation(roPtc.Data.point, roPtc.Data.posxz);
			}
		}
	}
}
