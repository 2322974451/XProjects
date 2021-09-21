using System;

namespace XUtliPoolLib
{
	// Token: 0x02000263 RID: 611
	public class EquipFusionTable : CVSReader
	{
		// Token: 0x06000D29 RID: 3369 RVA: 0x00045748 File Offset: 0x00043948
		protected override void ReadLine(XBinaryReader reader)
		{
			EquipFusionTable.RowData rowData = new EquipFusionTable.RowData();
			base.Read<uint>(reader, ref rowData.Profession, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<byte>(reader, ref rowData.Slot, CVSReader.byteParse);
			this.columnno = 1;
			base.Read<byte>(reader, ref rowData.EquipType, CVSReader.byteParse);
			this.columnno = 2;
			base.Read<byte>(reader, ref rowData.BreakNum, CVSReader.byteParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.LevelNum, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.NeedExpPerLevel, CVSReader.uintParse);
			this.columnno = 5;
			rowData.LevelAddAttr.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			rowData.BreakAddAttr.Read(reader, this.m_DataHandler);
			this.columnno = 7;
			rowData.BreakNeedMaterial.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D2A RID: 3370 RVA: 0x0004585C File Offset: 0x00043A5C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new EquipFusionTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007B1 RID: 1969
		public EquipFusionTable.RowData[] Table = null;

		// Token: 0x020003F2 RID: 1010
		public class RowData
		{
			// Token: 0x040011EE RID: 4590
			public uint Profession;

			// Token: 0x040011EF RID: 4591
			public byte Slot;

			// Token: 0x040011F0 RID: 4592
			public byte EquipType;

			// Token: 0x040011F1 RID: 4593
			public byte BreakNum;

			// Token: 0x040011F2 RID: 4594
			public uint LevelNum;

			// Token: 0x040011F3 RID: 4595
			public uint NeedExpPerLevel;

			// Token: 0x040011F4 RID: 4596
			public SeqListRef<uint> LevelAddAttr;

			// Token: 0x040011F5 RID: 4597
			public SeqListRef<uint> BreakAddAttr;

			// Token: 0x040011F6 RID: 4598
			public SeqListRef<uint> BreakNeedMaterial;
		}
	}
}
