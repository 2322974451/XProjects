using System;

namespace XMainClient
{

	public class GuildWeeklyTaskInfo
	{

		public uint taskID;

		public uint step;

		public bool isRewarded;

		public bool hasAsked;

		public uint refreshedCount;

		public uint originIndex;

		public WeeklyTaskCategory category;
	}
}
