using System;

namespace XUtliPoolLib
{
	// Token: 0x02000142 RID: 322
	public class PetLevelTable : CVSReader
	{
		// Token: 0x06000770 RID: 1904 RVA: 0x000259D4 File Offset: 0x00023BD4
		protected override void ReadLine(XBinaryReader reader)
		{
			PetLevelTable.RowData rowData = new PetLevelTable.RowData();
			base.Read<uint>(reader, ref rowData.PetsID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.exp, CVSReader.uintParse);
			this.columnno = 2;
			rowData.PetsAttributes.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x00025A68 File Offset: 0x00023C68
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PetLevelTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400038E RID: 910
		public PetLevelTable.RowData[] Table = null;

		// Token: 0x02000341 RID: 833
		public class RowData
		{
			// Token: 0x04000CEC RID: 3308
			public uint PetsID;

			// Token: 0x04000CED RID: 3309
			public uint level;

			// Token: 0x04000CEE RID: 3310
			public uint exp;

			// Token: 0x04000CEF RID: 3311
			public SeqListRef<uint> PetsAttributes;
		}
	}
}
