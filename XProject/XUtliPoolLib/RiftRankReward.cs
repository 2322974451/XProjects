using System;

namespace XUtliPoolLib
{

	public class RiftRankReward : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			RiftRankReward.RowData rowData = new RiftRankReward.RowData();
			base.Read<int>(reader, ref rowData.levelrange, CVSReader.intParse);
			this.columnno = 0;
			rowData.rank.Read(reader, this.m_DataHandler);
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
				this.Table = new RiftRankReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public RiftRankReward.RowData[] Table = null;

		public class RowData
		{

			public int levelrange;

			public SeqRef<uint> rank;

			public SeqListRef<uint> reward;
		}
	}
}
