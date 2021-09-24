using System;

namespace XUtliPoolLib
{

	public class PetInfoTable : CVSReader
	{

		public PetInfoTable.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PetInfoTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].id == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			PetInfoTable.RowData rowData = new PetInfoTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.quality, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadArray<uint>(reader, ref rowData.LvRequire, CVSReader.uintParse);
			this.columnno = 10;
			rowData.skill1.Read(reader, this.m_DataHandler);
			this.columnno = 11;
			rowData.skill2.Read(reader, this.m_DataHandler);
			this.columnno = 12;
			rowData.skill3.Read(reader, this.m_DataHandler);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.SpeedBuff, CVSReader.uintParse);
			this.columnno = 16;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 18;
			base.Read<uint>(reader, ref rowData.randSkillMax, CVSReader.uintParse);
			this.columnno = 19;
			base.Read<uint>(reader, ref rowData.maxHungry, CVSReader.uintParse);
			this.columnno = 21;
			base.Read<uint>(reader, ref rowData.presentID, CVSReader.uintParse);
			this.columnno = 24;
			base.Read<uint>(reader, ref rowData.PetType, CVSReader.uintParse);
			this.columnno = 28;
			base.Read<uint>(reader, ref rowData.WithWings, CVSReader.uintParse);
			this.columnno = 29;
			base.Read<string>(reader, ref rowData.Atlas, CVSReader.stringParse);
			this.columnno = 30;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PetInfoTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PetInfoTable.RowData[] Table = null;

		public class RowData
		{

			public uint id;

			public string name;

			public uint quality;

			public uint[] LvRequire;

			public SeqListRef<uint> skill1;

			public SeqListRef<uint> skill2;

			public SeqListRef<uint> skill3;

			public uint SpeedBuff;

			public string icon;

			public uint randSkillMax;

			public uint maxHungry;

			public uint presentID;

			public uint PetType;

			public uint WithWings;

			public string Atlas;
		}
	}
}
