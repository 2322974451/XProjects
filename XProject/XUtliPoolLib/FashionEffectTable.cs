using System;

namespace XUtliPoolLib
{
	// Token: 0x0200021B RID: 539
	public class FashionEffectTable : CVSReader
	{
		// Token: 0x06000C20 RID: 3104 RVA: 0x0003FAE4 File Offset: 0x0003DCE4
		protected override void ReadLine(XBinaryReader reader)
		{
			FashionEffectTable.RowData rowData = new FashionEffectTable.RowData();
			base.Read<uint>(reader, ref rowData.Quality, CVSReader.uintParse);
			this.columnno = 0;
			rowData.Effect2.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.Effect3.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			rowData.Effect4.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			rowData.Effect5.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.Effect6.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			rowData.Effect7.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			base.Read<bool>(reader, ref rowData.IsThreeSuit, CVSReader.boolParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x0003FBE0 File Offset: 0x0003DDE0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FashionEffectTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000769 RID: 1897
		public FashionEffectTable.RowData[] Table = null;

		// Token: 0x020003AA RID: 938
		public class RowData
		{
			// Token: 0x04001068 RID: 4200
			public uint Quality;

			// Token: 0x04001069 RID: 4201
			public SeqListRef<uint> Effect2;

			// Token: 0x0400106A RID: 4202
			public SeqListRef<uint> Effect3;

			// Token: 0x0400106B RID: 4203
			public SeqListRef<uint> Effect4;

			// Token: 0x0400106C RID: 4204
			public SeqListRef<uint> Effect5;

			// Token: 0x0400106D RID: 4205
			public SeqListRef<uint> Effect6;

			// Token: 0x0400106E RID: 4206
			public SeqListRef<uint> Effect7;

			// Token: 0x0400106F RID: 4207
			public bool IsThreeSuit;
		}
	}
}
