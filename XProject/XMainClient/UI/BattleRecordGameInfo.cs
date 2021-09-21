using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient.UI
{
	// Token: 0x02001794 RID: 6036
	internal class BattleRecordGameInfo
	{
		// Token: 0x04006CDA RID: 27866
		public List<BattleRecordPlayerInfo> left = new List<BattleRecordPlayerInfo>();

		// Token: 0x04006CDB RID: 27867
		public List<BattleRecordPlayerInfo> right = new List<BattleRecordPlayerInfo>();

		// Token: 0x04006CDC RID: 27868
		public HeroBattleOver result;

		// Token: 0x04006CDD RID: 27869
		public int point2V2;

		// Token: 0x04006CDE RID: 27870
		public uint militaryExploit;
	}
}
