using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B1E RID: 2846
	internal class EntityMask
	{
		// Token: 0x0600A74A RID: 42826 RVA: 0x001D90FC File Offset: 0x001D72FC
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

		// Token: 0x04003DC0 RID: 15808
		public static uint Moba_Home = 4U;

		// Token: 0x04003DC1 RID: 15809
		public static uint Moba_Tower = 8U;

		// Token: 0x04003DC2 RID: 15810
		public static uint Role = 1U;

		// Token: 0x04003DC3 RID: 15811
		public static uint Fade = 2147483648U;
	}
}
