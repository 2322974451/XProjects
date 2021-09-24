using System;

namespace XUtliPoolLib
{

	public class RiftWelfareReward : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			RiftWelfareReward.RowData rowData = new RiftWelfareReward.RowData();
			base.Read<int>(reader, ref rowData.levelrange, CVSReader.intParse);
			this.columnno = 0;
			rowData.floor.Read(reader, this.m_DataHandler);
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
				this.Table = new RiftWelfareReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public RiftWelfareReward.RowData[] Table = null;

		public class RowData
		{

			public int levelrange;

			public SeqRef<int> floor;

			public SeqListRef<uint> reward;
		}
	}
}
