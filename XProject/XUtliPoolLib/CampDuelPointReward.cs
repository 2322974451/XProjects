using System;

namespace XUtliPoolLib
{

	public class CampDuelPointReward : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			CampDuelPointReward.RowData rowData = new CampDuelPointReward.RowData();
			base.Read<int>(reader, ref rowData.CampID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Point, CVSReader.intParse);
			this.columnno = 1;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			rowData.EXReward.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CampDuelPointReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public CampDuelPointReward.RowData[] Table = null;

		public class RowData
		{

			public int CampID;

			public int Point;

			public SeqListRef<int> Reward;

			public SeqRef<int> EXReward;

			public string Icon;
		}
	}
}
