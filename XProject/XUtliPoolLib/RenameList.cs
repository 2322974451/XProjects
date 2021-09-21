using System;

namespace XUtliPoolLib
{
	// Token: 0x02000164 RID: 356
	public class RenameList : CVSReader
	{
		// Token: 0x060007EA RID: 2026 RVA: 0x0002821C File Offset: 0x0002641C
		public RenameList.RowData GetByid(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			RenameList.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].id == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x00028288 File Offset: 0x00026488
		protected override void ReadLine(XBinaryReader reader)
		{
			RenameList.RowData rowData = new RenameList.RowData();
			base.Read<int>(reader, ref rowData.id, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.cost, CVSReader.intParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x000282E8 File Offset: 0x000264E8
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RenameList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003B0 RID: 944
		public RenameList.RowData[] Table = null;

		// Token: 0x02000363 RID: 867
		public class RowData
		{
			// Token: 0x04000D8F RID: 3471
			public int id;

			// Token: 0x04000D90 RID: 3472
			public int cost;
		}
	}
}
