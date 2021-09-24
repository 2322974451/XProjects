using System;

namespace XUtliPoolLib
{

	public class GuildPkRankReward : CVSReader
	{

		public GuildPkRankReward.RowData GetByrank(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildPkRankReward.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].rank == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			GuildPkRankReward.RowData rowData = new GuildPkRankReward.RowData();
			base.Read<uint>(reader, ref rowData.rank, CVSReader.uintParse);
			this.columnno = 0;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildPkRankReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildPkRankReward.RowData[] Table = null;

		public class RowData
		{

			public uint rank;

			public SeqListRef<uint> reward;
		}
	}
}
