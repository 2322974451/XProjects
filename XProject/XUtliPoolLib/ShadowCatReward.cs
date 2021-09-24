using System;

namespace XUtliPoolLib
{

	public class ShadowCatReward : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			ShadowCatReward.RowData rowData = new ShadowCatReward.RowData();
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ShadowCatReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ShadowCatReward.RowData[] Table = null;

		public class RowData
		{

			public SeqListRef<uint> Reward;
		}
	}
}
