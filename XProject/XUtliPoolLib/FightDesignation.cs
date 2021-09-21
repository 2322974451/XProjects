using System;

namespace XUtliPoolLib
{
	// Token: 0x020000EE RID: 238
	public class FightDesignation : CVSReader
	{
		// Token: 0x06000638 RID: 1592 RVA: 0x0001E1A4 File Offset: 0x0001C3A4
		protected override void ReadLine(XBinaryReader reader)
		{
			FightDesignation.RowData rowData = new FightDesignation.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Designation, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Effect, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Color, CVSReader.stringParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x0001E238 File Offset: 0x0001C438
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FightDesignation.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400033A RID: 826
		public FightDesignation.RowData[] Table = null;

		// Token: 0x020002ED RID: 749
		public class RowData
		{
			// Token: 0x04000AC0 RID: 2752
			public uint ID;

			// Token: 0x04000AC1 RID: 2753
			public string Designation;

			// Token: 0x04000AC2 RID: 2754
			public string Effect;

			// Token: 0x04000AC3 RID: 2755
			public string Color;
		}
	}
}
