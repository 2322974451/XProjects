using System;

namespace XUtliPoolLib
{

	public class GuildSkillTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			GuildSkillTable.RowData rowData = new GuildSkillTable.RowData();
			base.Read<uint>(reader, ref rowData.skillid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 2;
			rowData.need.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.rexp, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.glevel, CVSReader.uintParse);
			this.columnno = 5;
			rowData.attribute.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.atlas, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.currentLevelDescription, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.roleLevel, CVSReader.uintParse);
			this.columnno = 10;
			base.ReadArray<uint>(reader, ref rowData.profecssion, CVSReader.uintParse);
			this.columnno = 11;
			base.Read<uint>(reader, ref rowData.needtype, CVSReader.uintParse);
			this.columnno = 12;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildSkillTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildSkillTable.RowData[] Table = null;

		public class RowData
		{

			public uint skillid;

			public string name;

			public uint level;

			public SeqListRef<uint> need;

			public uint rexp;

			public uint glevel;

			public SeqListRef<uint> attribute;

			public string icon;

			public string atlas;

			public string currentLevelDescription;

			public uint roleLevel;

			public uint[] profecssion;

			public uint needtype;
		}
	}
}
