using System;

namespace XUtliPoolLib
{

	public class DragonGuildAchieveTable : CVSReader
	{

		public DragonGuildAchieveTable.RowData GetByID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			DragonGuildAchieveTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ID == key;
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
			DragonGuildAchieveTable.RowData rowData = new DragonGuildAchieveTable.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.description, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.count, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.guildExp, CVSReader.uintParse);
			this.columnno = 7;
			base.ReadArray<uint>(reader, ref rowData.dropID, CVSReader.uintParse);
			this.columnno = 8;
			rowData.viewabledrop.Read(reader, this.m_DataHandler);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.chestCount, CVSReader.uintParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.value, CVSReader.uintParse);
			this.columnno = 11;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DragonGuildAchieveTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public DragonGuildAchieveTable.RowData[] Table = null;

		public class RowData
		{

			public uint ID;

			public uint Type;

			public string name;

			public string description;

			public string icon;

			public uint SceneID;

			public uint count;

			public uint guildExp;

			public uint[] dropID;

			public SeqListRef<uint> viewabledrop;

			public uint chestCount;

			public uint value;
		}
	}
}
