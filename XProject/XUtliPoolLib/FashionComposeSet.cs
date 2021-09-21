using System;

namespace XUtliPoolLib
{
	// Token: 0x020000E9 RID: 233
	public class FashionComposeSet : CVSReader
	{
		// Token: 0x06000625 RID: 1573 RVA: 0x0001D988 File Offset: 0x0001BB88
		protected override void ReadLine(XBinaryReader reader)
		{
			FashionComposeSet.RowData rowData = new FashionComposeSet.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.LevelSeal, CVSReader.uintParse);
			this.columnno = 1;
			rowData.Time.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			rowData.FashionSet.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x0001DA1C File Offset: 0x0001BC1C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FashionComposeSet.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000335 RID: 821
		public FashionComposeSet.RowData[] Table = null;

		// Token: 0x020002E8 RID: 744
		public class RowData
		{
			// Token: 0x04000A98 RID: 2712
			public uint Type;

			// Token: 0x04000A99 RID: 2713
			public uint LevelSeal;

			// Token: 0x04000A9A RID: 2714
			public SeqRef<string> Time;

			// Token: 0x04000A9B RID: 2715
			public SeqRef<uint> FashionSet;
		}
	}
}
