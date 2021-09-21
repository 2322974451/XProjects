using System;

namespace XUtliPoolLib
{
	// Token: 0x020000E4 RID: 228
	public class EnhanceTable : CVSReader
	{
		// Token: 0x0600060F RID: 1551 RVA: 0x0001CBE8 File Offset: 0x0001ADE8
		protected override void ReadLine(XBinaryReader reader)
		{
			EnhanceTable.RowData rowData = new EnhanceTable.RowData();
			base.Read<uint>(reader, ref rowData.EquipPos, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.EnhanceLevel, CVSReader.uintParse);
			this.columnno = 1;
			rowData.NeedItem.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.SuccessRate, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.UpRate, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.IsNeedBreak, CVSReader.uintParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x0001CCB0 File Offset: 0x0001AEB0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new EnhanceTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000330 RID: 816
		public EnhanceTable.RowData[] Table = null;

		// Token: 0x020002E3 RID: 739
		public class RowData
		{
			// Token: 0x04000A4C RID: 2636
			public uint EquipPos;

			// Token: 0x04000A4D RID: 2637
			public uint EnhanceLevel;

			// Token: 0x04000A4E RID: 2638
			public SeqListRef<uint> NeedItem;

			// Token: 0x04000A4F RID: 2639
			public uint SuccessRate;

			// Token: 0x04000A50 RID: 2640
			public uint UpRate;

			// Token: 0x04000A51 RID: 2641
			public uint IsNeedBreak;
		}
	}
}
