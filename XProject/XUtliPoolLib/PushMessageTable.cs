using System;

namespace XUtliPoolLib
{

	public class PushMessageTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			PushMessageTable.RowData rowData = new PushMessageTable.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Title, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Content, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.IsCommonGlobal, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadArray<uint>(reader, ref rowData.Time, CVSReader.uintParse);
			this.columnno = 6;
			base.ReadArray<uint>(reader, ref rowData.WeekDay, CVSReader.uintParse);
			this.columnno = 8;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PushMessageTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PushMessageTable.RowData[] Table = null;

		public class RowData
		{

			public uint Type;

			public string Title;

			public string Content;

			public uint IsCommonGlobal;

			public uint[] Time;

			public uint[] WeekDay;
		}
	}
}
