using System;

namespace XUtliPoolLib
{
	// Token: 0x02000240 RID: 576
	public class OpenServerActivity : CVSReader
	{
		// Token: 0x06000CA8 RID: 3240 RVA: 0x000428D0 File Offset: 0x00040AD0
		public OpenServerActivity.RowData GetByServerLevel(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			OpenServerActivity.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchServerLevel(key);
			}
			return result;
		}

		// Token: 0x06000CA9 RID: 3241 RVA: 0x00042908 File Offset: 0x00040B08
		private OpenServerActivity.RowData BinarySearchServerLevel(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			OpenServerActivity.RowData rowData;
			OpenServerActivity.RowData rowData2;
			OpenServerActivity.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.ServerLevel == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.ServerLevel == key;
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
				bool flag4 = rowData3.ServerLevel.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.ServerLevel.CompareTo(key) < 0;
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

		// Token: 0x06000CAA RID: 3242 RVA: 0x000429E4 File Offset: 0x00040BE4
		protected override void ReadLine(XBinaryReader reader)
		{
			OpenServerActivity.RowData rowData = new OpenServerActivity.RowData();
			base.Read<uint>(reader, ref rowData.ServerLevel, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.TaskIDs, CVSReader.uintParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CAB RID: 3243 RVA: 0x00042A44 File Offset: 0x00040C44
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new OpenServerActivity.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400078E RID: 1934
		public OpenServerActivity.RowData[] Table = null;

		// Token: 0x020003CF RID: 975
		public class RowData
		{
			// Token: 0x04001125 RID: 4389
			public uint ServerLevel;

			// Token: 0x04001126 RID: 4390
			public uint[] TaskIDs;
		}
	}
}
