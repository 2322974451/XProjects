using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class EntityMask
	{

		public static uint CreateTag(XEntityStatistics.RowData data)
		{
			uint num = 0U;
			bool flag = data != null && data.Tag != null;
			if (flag)
			{
				for (int i = 0; i < data.Tag.Length; i++)
				{
					num |= 1U << (int)data.Tag[i];
				}
			}
			return num;
		}

		public static uint Moba_Home = 4U;

		public static uint Moba_Tower = 8U;

		public static uint Role = 1U;

		public static uint Fade = 2147483648U;
	}
}
