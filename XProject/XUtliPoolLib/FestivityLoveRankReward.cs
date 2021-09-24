using System;

namespace XUtliPoolLib
{

	public class FestivityLoveRankReward : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			FestivityLoveRankReward.RowData rowData = new FestivityLoveRankReward.RowData();
			rowData.LoveRank.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			rowData.RankReward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.DesignationId, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.DesignationIcon, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FestivityLoveRankReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FestivityLoveRankReward.RowData[] Table = null;

		public class RowData
		{

			public SeqRef<uint> LoveRank;

			public SeqListRef<uint> RankReward;

			public uint DesignationId;

			public string DesignationIcon;
		}
	}
}
