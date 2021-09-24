using System;

namespace XUtliPoolLib
{

	public class CustomBattleTable : CVSReader
	{

		public CustomBattleTable.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			CustomBattleTable.RowData result;
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
			CustomBattleTable.RowData rowData = new CustomBattleTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.type, CVSReader.uintParse);
			this.columnno = 1;
			rowData.create.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.joincount, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.readytimepan, CVSReader.uintParse);
			this.columnno = 4;
			base.ReadArray<uint>(reader, ref rowData.timespan, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.levellimit, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.desc, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.BoxSpriteName, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<int>(reader, ref rowData.ExpID, CVSReader.intParse);
			this.columnno = 11;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CustomBattleTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public CustomBattleTable.RowData[] Table = null;

		public class RowData
		{

			public uint id;

			public uint type;

			public SeqListRef<uint> create;

			public uint joincount;

			public uint readytimepan;

			public uint[] timespan;

			public uint levellimit;

			public string desc;

			public string BoxSpriteName;

			public int ExpID;
		}
	}
}
