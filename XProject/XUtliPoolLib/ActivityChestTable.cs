using System;

namespace XUtliPoolLib
{
	// Token: 0x020000AC RID: 172
	public class ActivityChestTable : CVSReader
	{
		// Token: 0x06000527 RID: 1319 RVA: 0x00016954 File Offset: 0x00014B54
		protected override void ReadLine(XBinaryReader reader)
		{
			ActivityChestTable.RowData rowData = new ActivityChestTable.RowData();
			base.Read<uint>(reader, ref rowData.chest, CVSReader.uintParse);
			this.columnno = 0;
			rowData.level.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.viewabledrop.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x000169CC File Offset: 0x00014BCC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ActivityChestTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002D2 RID: 722
		public ActivityChestTable.RowData[] Table = null;

		// Token: 0x020002AA RID: 682
		public class RowData
		{
			// Token: 0x040008CA RID: 2250
			public uint chest;

			// Token: 0x040008CB RID: 2251
			public SeqRef<uint> level;

			// Token: 0x040008CC RID: 2252
			public SeqListRef<uint> viewabledrop;
		}
	}
}
