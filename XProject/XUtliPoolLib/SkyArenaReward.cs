using System;

namespace XUtliPoolLib
{

	public class SkyArenaReward : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			SkyArenaReward.RowData rowData = new SkyArenaReward.RowData();
			base.Read<int>(reader, ref rowData.LevelSegment, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Floor, CVSReader.intParse);
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
				this.Table = new SkyArenaReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public SkyArenaReward.RowData[] Table = null;

		public class RowData
		{

			public int LevelSegment;

			public int Floor;

			public SeqListRef<uint> Reward;
		}
	}
}
