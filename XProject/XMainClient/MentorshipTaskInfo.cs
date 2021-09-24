using System;
using System.Collections.Generic;

namespace XMainClient
{

	public class MentorshipTaskInfo
	{

		public int taskID;

		public int completeProgress;

		public int completeTime;

		public List<MentorshipTaskStatus> taskStatusList = new List<MentorshipTaskStatus>();
	}
}
