using System;

namespace XUtliPoolLib
{
	// Token: 0x0200026E RID: 622
	public class DoubleActivity : CVSReader
	{
		// Token: 0x06000D4A RID: 3402 RVA: 0x00046278 File Offset: 0x00044478
		public DoubleActivity.RowData GetBySystemId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			DoubleActivity.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SystemId == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000D4B RID: 3403 RVA: 0x000462E4 File Offset: 0x000444E4
		protected override void ReadLine(XBinaryReader reader)
		{
			DoubleActivity.RowData rowData = new DoubleActivity.RowData();
			base.Read<uint>(reader, ref rowData.SystemId, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.WeekOpenDays, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadArray<uint>(reader, ref rowData.TimeSpan, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.DropMultiple, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.DropItems, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.LimitTimes, CVSReader.uintParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D4C RID: 3404 RVA: 0x000463AC File Offset: 0x000445AC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DoubleActivity.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007BC RID: 1980
		public DoubleActivity.RowData[] Table = null;

		// Token: 0x020003FD RID: 1021
		public class RowData
		{
			// Token: 0x0400122F RID: 4655
			public uint SystemId;

			// Token: 0x04001230 RID: 4656
			public uint[] WeekOpenDays;

			// Token: 0x04001231 RID: 4657
			public uint[] TimeSpan;

			// Token: 0x04001232 RID: 4658
			public uint DropMultiple;

			// Token: 0x04001233 RID: 4659
			public uint DropItems;

			// Token: 0x04001234 RID: 4660
			public uint LimitTimes;
		}
	}
}
