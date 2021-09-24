using System;

namespace XUtliPoolLib
{

	public class ChatApollo : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			ChatApollo.RowData rowData = new ChatApollo.RowData();
			base.Read<int>(reader, ref rowData.speak, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.music, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.click, CVSReader.intParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.note, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.opens, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.openm, CVSReader.intParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.note2, CVSReader.stringParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ChatApollo.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ChatApollo.RowData[] Table = null;

		public class RowData
		{

			public int speak;

			public int music;

			public int click;

			public string note;

			public int opens;

			public int openm;

			public string note2;
		}
	}
}
