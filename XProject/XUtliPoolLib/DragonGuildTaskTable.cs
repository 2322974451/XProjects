using System;

namespace XUtliPoolLib
{

	public class DragonGuildTaskTable : CVSReader
	{

		public DragonGuildTaskTable.RowData GetBytaskID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			DragonGuildTaskTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].taskID == key;
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
			DragonGuildTaskTable.RowData rowData = new DragonGuildTaskTable.RowData();
			base.Read<uint>(reader, ref rowData.taskID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.taskType, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 4;
			rowData.worldlevel.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.count, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.guildExp, CVSReader.uintParse);
			this.columnno = 7;
			rowData.viewabledrop.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			base.ReadArray<uint>(reader, ref rowData.dropID, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.value, CVSReader.uintParse);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DragonGuildTaskTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public DragonGuildTaskTable.RowData[] Table = null;

		public class RowData
		{

			public uint taskID;

			public uint taskType;

			public string name;

			public uint SceneID;

			public string icon;

			public SeqRef<uint> worldlevel;

			public uint count;

			public uint guildExp;

			public SeqListRef<uint> viewabledrop;

			public uint[] dropID;

			public uint value;
		}
	}
}
