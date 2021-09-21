using System;

namespace XUtliPoolLib
{
	// Token: 0x02000237 RID: 567
	public class MobaLevel : CVSReader
	{
		// Token: 0x06000C86 RID: 3206 RVA: 0x00041E78 File Offset: 0x00040078
		public MobaLevel.RowData GetByLevel(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			MobaLevel.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchLevel(key);
			}
			return result;
		}

		// Token: 0x06000C87 RID: 3207 RVA: 0x00041EB0 File Offset: 0x000400B0
		private MobaLevel.RowData BinarySearchLevel(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			MobaLevel.RowData rowData;
			MobaLevel.RowData rowData2;
			MobaLevel.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.Level == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.Level == key;
				if (flag2)
				{
					goto Block_2;
				}
				bool flag3 = num2 - num <= 1;
				if (flag3)
				{
					goto Block_3;
				}
				int num3 = num + (num2 - num) / 2;
				rowData3 = this.Table[num3];
				bool flag4 = rowData3.Level.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.Level.CompareTo(key) < 0;
					if (!flag5)
					{
						goto IL_B1;
					}
					num = num3;
				}
				if (num >= num2)
				{
					goto Block_6;
				}
			}
			return rowData;
			Block_2:
			return rowData2;
			Block_3:
			return null;
			IL_B1:
			return rowData3;
			Block_6:
			return null;
		}

		// Token: 0x06000C88 RID: 3208 RVA: 0x00041F8C File Offset: 0x0004018C
		protected override void ReadLine(XBinaryReader reader)
		{
			MobaLevel.RowData rowData = new MobaLevel.RowData();
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<double>(reader, ref rowData.Exp, CVSReader.doubleParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C89 RID: 3209 RVA: 0x00041FEC File Offset: 0x000401EC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new MobaLevel.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000785 RID: 1925
		public MobaLevel.RowData[] Table = null;

		// Token: 0x020003C6 RID: 966
		public class RowData
		{
			// Token: 0x04001106 RID: 4358
			public uint Level;

			// Token: 0x04001107 RID: 4359
			public double Exp;
		}
	}
}
