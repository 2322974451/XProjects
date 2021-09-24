using System;

namespace XUtliPoolLib
{

	public class EquipFusionTable : CVSReader
	{

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

		public EquipFusionTable.RowData[] Table = null;

		public class RowData
		{

			public uint Profession;

			public byte Slot;

			public byte EquipType;

			public byte BreakNum;

			public uint LevelNum;

			public uint NeedExpPerLevel;

			public SeqListRef<uint> LevelAddAttr;

			public SeqListRef<uint> BreakAddAttr;

			public SeqListRef<uint> BreakNeedMaterial;
		}
	}
}
