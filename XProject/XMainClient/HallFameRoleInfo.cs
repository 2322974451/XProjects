using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000912 RID: 2322
	public class HallFameRoleInfo
	{
		// Token: 0x04002D22 RID: 11554
		public uint Rank = 0U;

		// Token: 0x04002D23 RID: 11555
		public string IconName;

		// Token: 0x04002D24 RID: 11556
		public string TeamName;

		// Token: 0x04002D25 RID: 11557
		public string RoleName;

		// Token: 0x04002D26 RID: 11558
		public RoleOutLookBrief OutLook;

		// Token: 0x04002D27 RID: 11559
		public ArenaStarHistData hisData;

		// Token: 0x04002D28 RID: 11560
		public List<int> LastData = new List<int>();
	}
}
