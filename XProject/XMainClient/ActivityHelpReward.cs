using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C72 RID: 3186
	public class ActivityHelpReward
	{
		// Token: 0x0600B436 RID: 46134 RVA: 0x00232930 File Offset: 0x00230B30
		public static int Compare(ActivityHelpReward x, ActivityHelpReward y)
		{
			bool flag = x.sort != y.sort;
			int result;
			if (flag)
			{
				result = y.sort - x.sort;
			}
			else
			{
				result = x.index - y.index;
			}
			return result;
		}

		// Token: 0x040045E0 RID: 17888
		public int index;

		// Token: 0x040045E1 RID: 17889
		public SuperActivityTask.RowData tableData;

		// Token: 0x040045E2 RID: 17890
		public uint state;

		// Token: 0x040045E3 RID: 17891
		public int sort;

		// Token: 0x040045E4 RID: 17892
		public uint progress;
	}
}
