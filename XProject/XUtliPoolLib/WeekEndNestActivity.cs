using System;

namespace XUtliPoolLib
{
	// Token: 0x0200024B RID: 587
	public class WeekEndNestActivity : CVSReader
	{
		// Token: 0x06000CD2 RID: 3282 RVA: 0x000436E0 File Offset: 0x000418E0
		public WeekEndNestActivity.RowData GetByParentTaskId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			WeekEndNestActivity.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ParentTaskId == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000CD3 RID: 3283 RVA: 0x0004374C File Offset: 0x0004194C
		protected override void ReadLine(XBinaryReader reader)
		{
			WeekEndNestActivity.RowData rowData = new WeekEndNestActivity.RowData();
			rowData.OpenSvrDay.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.ParentTaskId, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.BgTexName, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CD4 RID: 3284 RVA: 0x000437C4 File Offset: 0x000419C4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new WeekEndNestActivity.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000799 RID: 1945
		public WeekEndNestActivity.RowData[] Table = null;

		// Token: 0x020003DA RID: 986
		public class RowData
		{
			// Token: 0x04001158 RID: 4440
			public SeqRef<uint> OpenSvrDay;

			// Token: 0x04001159 RID: 4441
			public uint ParentTaskId;

			// Token: 0x0400115A RID: 4442
			public string BgTexName;
		}
	}
}
