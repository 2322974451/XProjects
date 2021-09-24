using System;

namespace XUtliPoolLib
{

	public class GuildMineralStorage : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			GuildMineralStorage.RowData rowData = new GuildMineralStorage.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.effect, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.self, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.bufficon, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.buffdescribe, CVSReader.stringParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildMineralStorage.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildMineralStorage.RowData[] Table = null;

		public class RowData
		{

			public uint ID;

			public uint itemid;

			public string effect;

			public uint self;

			public string bufficon;

			public string buffdescribe;
		}
	}
}
