using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x0200094B RID: 2379
	public class MentorshipTaskInfo
	{
		// Token: 0x04002F3A RID: 12090
		public int taskID;

		// Token: 0x04002F3B RID: 12091
		public int completeProgress;

		// Token: 0x04002F3C RID: 12092
		public int completeTime;

		// Token: 0x04002F3D RID: 12093
		public List<MentorshipTaskStatus> taskStatusList = new List<MentorshipTaskStatus>();
	}
}
