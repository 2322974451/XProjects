using System;

namespace XUtliPoolLib
{

	public class GuildBuffTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			GuildBuffTable.RowData rowData = new GuildBuffTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildBuffTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildBuffTable.RowData[] Table = null;

		public class RowData
		{

			public uint id;

			public uint itemid;
		}
	}
}
