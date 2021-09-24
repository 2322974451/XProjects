using System;

namespace XUtliPoolLib
{

	public class BigMeleePointReward : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			BigMeleePointReward.RowData rowData = new BigMeleePointReward.RowData();
			rowData.levelrange.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.point, CVSReader.intParse);
			this.columnno = 1;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BigMeleePointReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public BigMeleePointReward.RowData[] Table = null;

		public class RowData
		{

			public SeqRef<int> levelrange;

			public int point;

			public SeqListRef<int> reward;
		}
	}
}
