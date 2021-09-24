using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class MulActivityInfo
	{

		public int ID;

		public uint roleLevel;

		public MulActivityState state;

		public MulActivityTagType tagType;

		public MulActivityTimeState timeState;

		public double time;

		public int startTime;

		public int endTime;

		public int dayjoincount;

		public bool openState;

		public bool isOpenAllDay = false;

		public int sortWeight = 0;

		public int serverOpenDayLeft;

		public int serverOpenWeekLeft;

		public MultiActivityList.RowData Row;
	}
}
