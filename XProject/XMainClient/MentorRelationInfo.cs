using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200094D RID: 2381
	public class MentorRelationInfo
	{
		// Token: 0x04002F41 RID: 12097
		public RoleBriefInfo roleInfo;

		// Token: 0x04002F42 RID: 12098
		public MentorRelationStatus status;

		// Token: 0x04002F43 RID: 12099
		public List<MentorRelationTime> statusTimeList = new List<MentorRelationTime>();

		// Token: 0x04002F44 RID: 12100
		public List<MentorshipTaskInfo> taskList = new List<MentorshipTaskInfo>();

		// Token: 0x04002F45 RID: 12101
		public EMentorTaskStatus inheritStatus;

		// Token: 0x04002F46 RID: 12102
		public ulong breakApplyRoleID;

		// Token: 0x04002F47 RID: 12103
		public ulong inheritApplyRoleID = 0UL;
	}
}
