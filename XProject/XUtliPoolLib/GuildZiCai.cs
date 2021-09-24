using System;

namespace XUtliPoolLib
{

	public class GuildZiCai : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			GuildZiCai.RowData rowData = new GuildZiCai.RowData();
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 0;
			rowData.rolerewards.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.guildrewards.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.ShowTips, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.senior, CVSReader.uintParse);
			this.columnno = 4;
			rowData.roleextrarewards.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildZiCai.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildZiCai.RowData[] Table = null;

		public class RowData
		{

			public uint itemid;

			public SeqListRef<uint> rolerewards;

			public SeqListRef<uint> guildrewards;

			public string ShowTips;

			public uint senior;

			public SeqRef<uint> roleextrarewards;
		}
	}
}
