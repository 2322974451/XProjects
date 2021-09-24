using System;

namespace XUtliPoolLib
{

	public class CustomBattleSystemTable : CVSReader
	{

		public CustomBattleSystemTable.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			CustomBattleSystemTable.RowData result;
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
			CustomBattleSystemTable.RowData rowData = new CustomBattleSystemTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.type, CVSReader.uintParse);
			this.columnno = 1;
			rowData.end.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			rowData.ticket.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.levellimit, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.desc, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.TitleSpriteName, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.IconSpritePath, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.ExpID, CVSReader.intParse);
			this.columnno = 8;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CustomBattleSystemTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public CustomBattleSystemTable.RowData[] Table = null;

		public class RowData
		{

			public uint id;

			public uint type;

			public SeqRef<uint> end;

			public SeqRef<uint> ticket;

			public uint levellimit;

			public string desc;

			public string TitleSpriteName;

			public string IconSpritePath;

			public int ExpID;
		}
	}
}
