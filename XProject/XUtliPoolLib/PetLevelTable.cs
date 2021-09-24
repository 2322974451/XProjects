using System;

namespace XUtliPoolLib
{

	public class PetLevelTable : CVSReader
	{

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

		public PetLevelTable.RowData[] Table = null;

		public class RowData
		{

			public uint PetsID;

			public uint level;

			public uint exp;

			public SeqListRef<uint> PetsAttributes;
		}
	}
}
