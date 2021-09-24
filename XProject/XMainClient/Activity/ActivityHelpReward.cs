using System;
using XUtliPoolLib;

namespace XMainClient
{

	public class ActivityHelpReward
	{

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

		public int index;

		public SuperActivityTask.RowData tableData;

		public uint state;

		public int sort;

		public uint progress;
	}
}
