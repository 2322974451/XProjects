using System;

namespace XMainClient
{
	// Token: 0x020015F2 RID: 5618
	internal class Process_PtcG2C_BattleFieldReliveNtf
	{
		// Token: 0x0600ECF6 RID: 60662 RVA: 0x00347C24 File Offset: 0x00345E24
		public static void Process(PtcG2C_BattleFieldReliveNtf roPtc)
		{
			XBattleFieldBattleDocument.Doc.SetReviveTime(roPtc);
		}
	}
}
