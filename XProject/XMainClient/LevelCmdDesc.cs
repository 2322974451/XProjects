using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000DF2 RID: 3570
	internal class LevelCmdDesc
	{
		// Token: 0x0600C121 RID: 49441 RVA: 0x0028E71F File Offset: 0x0028C91F
		public void Reset()
		{
			this.state = XCmdState.Cmd_In_Queue;
		}

		// Token: 0x0400515B RID: 20827
		public LevelCmd cmd = LevelCmd.Level_Cmd_Invalid;

		// Token: 0x0400515C RID: 20828
		public List<string> Param = new List<string>();

		// Token: 0x0400515D RID: 20829
		public XCmdState state = XCmdState.Cmd_In_Queue;
	}
}
