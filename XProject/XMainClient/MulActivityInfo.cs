using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009C3 RID: 2499
	internal class MulActivityInfo
	{
		// Token: 0x040033C2 RID: 13250
		public int ID;

		// Token: 0x040033C3 RID: 13251
		public uint roleLevel;

		// Token: 0x040033C4 RID: 13252
		public MulActivityState state;

		// Token: 0x040033C5 RID: 13253
		public MulActivityTagType tagType;

		// Token: 0x040033C6 RID: 13254
		public MulActivityTimeState timeState;

		// Token: 0x040033C7 RID: 13255
		public double time;

		// Token: 0x040033C8 RID: 13256
		public int startTime;

		// Token: 0x040033C9 RID: 13257
		public int endTime;

		// Token: 0x040033CA RID: 13258
		public int dayjoincount;

		// Token: 0x040033CB RID: 13259
		public bool openState;

		// Token: 0x040033CC RID: 13260
		public bool isOpenAllDay = false;

		// Token: 0x040033CD RID: 13261
		public int sortWeight = 0;

		// Token: 0x040033CE RID: 13262
		public int serverOpenDayLeft;

		// Token: 0x040033CF RID: 13263
		public int serverOpenWeekLeft;

		// Token: 0x040033D0 RID: 13264
		public MultiActivityList.RowData Row;
	}
}
