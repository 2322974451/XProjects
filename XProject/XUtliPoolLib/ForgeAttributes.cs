using System;

namespace XUtliPoolLib
{
	// Token: 0x020000F8 RID: 248
	public class ForgeAttributes : CVSReader
	{
		// Token: 0x06000658 RID: 1624 RVA: 0x0001EAEC File Offset: 0x0001CCEC
		protected override void ReadLine(XBinaryReader reader)
		{
			ForgeAttributes.RowData rowData = new ForgeAttributes.RowData();
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

		// Token: 0x06000659 RID: 1625 RVA: 0x0001EBB4 File Offset: 0x0001CDB4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ForgeAttributes.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000344 RID: 836
		public ForgeAttributes.RowData[] Table = null;

		// Token: 0x020002F7 RID: 759
		public class RowData
		{
			// Token: 0x04000AEA RID: 2794
			public uint EquipID;

			// Token: 0x04000AEB RID: 2795
			public byte Slot;

			// Token: 0x04000AEC RID: 2796
			public byte AttrID;

			// Token: 0x04000AED RID: 2797
			public byte Prob;

			// Token: 0x04000AEE RID: 2798
			public SeqRef<uint> Range;

			// Token: 0x04000AEF RID: 2799
			public byte CanSmelt;
		}
	}
}
