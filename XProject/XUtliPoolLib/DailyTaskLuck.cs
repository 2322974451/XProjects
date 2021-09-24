using System;

namespace XUtliPoolLib
{

	public class DailyTaskLuck : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			DailyTaskLuck.RowData rowData = new DailyTaskLuck.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			rowData.prob.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.getProb, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.backflowProb, CVSReader.uintParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DailyTaskLuck.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public DailyTaskLuck.RowData[] Table = null;

		public class RowData
		{

			public uint id;

			public string name;

			public SeqListRef<uint> prob;

			public uint getProb;

			public uint backflowProb;
		}
	}
}
