using System;

namespace XUtliPoolLib
{

	public class AncientTask : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			AncientTask.RowData rowData = new AncientTask.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.title, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.content, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.time, CVSReader.stringParse);
			this.columnno = 3;
			rowData.rewards.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new AncientTask.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public AncientTask.RowData[] Table = null;

		public class RowData
		{

			public uint ID;

			public string title;

			public string content;

			public string time;

			public SeqListRef<uint> rewards;
		}
	}
}
