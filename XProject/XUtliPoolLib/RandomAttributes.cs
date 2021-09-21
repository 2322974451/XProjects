using System;

namespace XUtliPoolLib
{
	// Token: 0x0200015D RID: 349
	public class RandomAttributes : CVSReader
	{
		// Token: 0x060007D2 RID: 2002 RVA: 0x00027AA0 File Offset: 0x00025CA0
		protected override void ReadLine(XBinaryReader reader)
		{
			RandomAttributes.RowData rowData = new RandomAttributes.RowData();
			base.Read<uint>(reader, ref rowData.EquipID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<byte>(reader, ref rowData.Slot, CVSReader.byteParse);
			this.columnno = 1;
			base.Read<byte>(reader, ref rowData.AttrID, CVSReader.byteParse);
			this.columnno = 2;
			base.Read<byte>(reader, ref rowData.Prob, CVSReader.byteParse);
			this.columnno = 3;
			rowData.Range.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			base.Read<byte>(reader, ref rowData.CanSmelt, CVSReader.byteParse);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x00027B68 File Offset: 0x00025D68
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RandomAttributes.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003A9 RID: 937
		public RandomAttributes.RowData[] Table = null;

		// Token: 0x0200035C RID: 860
		public class RowData
		{
			// Token: 0x04000D71 RID: 3441
			public uint EquipID;

			// Token: 0x04000D72 RID: 3442
			public byte Slot;

			// Token: 0x04000D73 RID: 3443
			public byte AttrID;

			// Token: 0x04000D74 RID: 3444
			public byte Prob;

			// Token: 0x04000D75 RID: 3445
			public SeqRef<uint> Range;

			// Token: 0x04000D76 RID: 3446
			public byte CanSmelt;
		}
	}
}
