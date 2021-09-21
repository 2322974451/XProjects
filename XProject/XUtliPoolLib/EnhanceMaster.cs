using System;

namespace XUtliPoolLib
{
	// Token: 0x020000E3 RID: 227
	public class EnhanceMaster : CVSReader
	{
		// Token: 0x0600060C RID: 1548 RVA: 0x0001CB30 File Offset: 0x0001AD30
		protected override void ReadLine(XBinaryReader reader)
		{
			EnhanceMaster.RowData rowData = new EnhanceMaster.RowData();
			base.Read<short>(reader, ref rowData.ProfessionId, CVSReader.shortParse);
			this.columnno = 0;
			base.Read<short>(reader, ref rowData.TotalEnhanceLevel, CVSReader.shortParse);
			this.columnno = 1;
			rowData.Attribute.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x0001CBA8 File Offset: 0x0001ADA8
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new EnhanceMaster.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400032F RID: 815
		public EnhanceMaster.RowData[] Table = null;

		// Token: 0x020002E2 RID: 738
		public class RowData
		{
			// Token: 0x04000A49 RID: 2633
			public short ProfessionId;

			// Token: 0x04000A4A RID: 2634
			public short TotalEnhanceLevel;

			// Token: 0x04000A4B RID: 2635
			public SeqListRef<uint> Attribute;
		}
	}
}
