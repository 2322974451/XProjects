using System;

namespace XUtliPoolLib
{
	// Token: 0x02000244 RID: 580
	public class AncientTimesTable : CVSReader
	{
		// Token: 0x06000CB8 RID: 3256 RVA: 0x00042EE4 File Offset: 0x000410E4
		protected override void ReadLine(XBinaryReader reader)
		{
			AncientTimesTable.RowData rowData = new AncientTimesTable.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			rowData.nPoints.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.Items.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Title, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CB9 RID: 3257 RVA: 0x00042F78 File Offset: 0x00041178
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new AncientTimesTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000792 RID: 1938
		public AncientTimesTable.RowData[] Table = null;

		// Token: 0x020003D3 RID: 979
		public class RowData
		{
			// Token: 0x0400113B RID: 4411
			public uint ID;

			// Token: 0x0400113C RID: 4412
			public SeqRef<uint> nPoints;

			// Token: 0x0400113D RID: 4413
			public SeqListRef<uint> Items;

			// Token: 0x0400113E RID: 4414
			public string Title;
		}
	}
}
