using System;

namespace XUtliPoolLib
{

	public class FirstPassReward : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			FirstPassReward.RowData rowData = new FirstPassReward.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			rowData.Rank.Read(reader, this.m_DataHandler);
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
				this.Table = new FirstPassReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FirstPassReward.RowData[] Table = null;

		public class RowData
		{

			public int ID;

			public SeqRef<int> Rank;

			public SeqListRef<int> Reward;
		}
	}
}
