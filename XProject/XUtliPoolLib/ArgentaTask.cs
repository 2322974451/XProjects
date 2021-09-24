using System;

namespace XUtliPoolLib
{

	public class ArgentaTask : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			ArgentaTask.RowData rowData = new ArgentaTask.RowData();
			rowData.LevelRange.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.TaskID, CVSReader.uintParse);
			this.columnno = 1;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ArgentaTask.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ArgentaTask.RowData[] Table = null;

		public class RowData
		{

			public SeqRef<uint> LevelRange;

			public uint TaskID;

			public SeqListRef<uint> Reward;
		}
	}
}
