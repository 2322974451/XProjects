using System;

namespace XUtliPoolLib
{

	public class GuildHall : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			GuildHall.RowData rowData = new GuildHall.RowData();
			base.Read<uint>(reader, ref rowData.skillid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.updateneed, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.dailyneed, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.glevel, CVSReader.uintParse);
			this.columnno = 5;
			rowData.buffid.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.atlas, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.currentLevelDescription, CVSReader.stringParse);
			this.columnno = 9;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildHall.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildHall.RowData[] Table = null;

		public class RowData
		{

			public uint skillid;

			public string name;

			public uint level;

			public uint updateneed;

			public uint dailyneed;

			public uint glevel;

			public SeqRef<uint> buffid;

			public string icon;

			public string atlas;

			public string currentLevelDescription;
		}
	}
}
