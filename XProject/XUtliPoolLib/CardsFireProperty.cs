using System;

namespace XUtliPoolLib
{
	// Token: 0x020000BE RID: 190
	public class CardsFireProperty : CVSReader
	{
		// Token: 0x06000568 RID: 1384 RVA: 0x000185E0 File Offset: 0x000167E0
		protected override void ReadLine(XBinaryReader reader)
		{
			CardsFireProperty.RowData rowData = new CardsFireProperty.RowData();
			base.Read<uint>(reader, ref rowData.GroupId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.FireCounts, CVSReader.uintParse);
			this.columnno = 1;
			rowData.Promote.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.BreakLevel, CVSReader.uintParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x00018674 File Offset: 0x00016874
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CardsFireProperty.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002E4 RID: 740
		public CardsFireProperty.RowData[] Table = null;

		// Token: 0x020002BC RID: 700
		public class RowData
		{
			// Token: 0x04000962 RID: 2402
			public uint GroupId;

			// Token: 0x04000963 RID: 2403
			public uint FireCounts;

			// Token: 0x04000964 RID: 2404
			public SeqListRef<uint> Promote;

			// Token: 0x04000965 RID: 2405
			public uint BreakLevel;
		}
	}
}
