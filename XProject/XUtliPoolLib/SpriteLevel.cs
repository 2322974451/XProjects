using System;

namespace XUtliPoolLib
{
	// Token: 0x02000170 RID: 368
	public class SpriteLevel : CVSReader
	{
		// Token: 0x0600081A RID: 2074 RVA: 0x0002A378 File Offset: 0x00028578
		protected override void ReadLine(XBinaryReader reader)
		{
			SpriteLevel.RowData rowData = new SpriteLevel.RowData();
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Quality, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.Exp, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<double>(reader, ref rowData.Ratio, CVSReader.doubleParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x0002A40C File Offset: 0x0002860C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SpriteLevel.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003BC RID: 956
		public SpriteLevel.RowData[] Table = null;

		// Token: 0x0200036F RID: 879
		public class RowData
		{
			// Token: 0x04000E68 RID: 3688
			public uint Level;

			// Token: 0x04000E69 RID: 3689
			public uint Quality;

			// Token: 0x04000E6A RID: 3690
			public uint Exp;

			// Token: 0x04000E6B RID: 3691
			public double Ratio;
		}
	}
}
