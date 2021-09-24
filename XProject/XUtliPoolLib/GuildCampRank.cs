using System;

namespace XUtliPoolLib
{

	public class GuildCampRank : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			GuildCampRank.RowData rowData = new GuildCampRank.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Rank, CVSReader.intParse);
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
				this.Table = new GuildCampRank.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildCampRank.RowData[] Table = null;

		public class RowData
		{

			public int ID;

			public int Rank;

			public SeqListRef<uint> Reward;
		}
	}
}
