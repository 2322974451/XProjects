using System;

namespace XUtliPoolLib
{

	public class GuildCampPartyReward : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			GuildCampPartyReward.RowData rowData = new GuildCampPartyReward.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			rowData.Items.Read(reader, this.m_DataHandler);
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
				this.Table = new GuildCampPartyReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildCampPartyReward.RowData[] Table = null;

		public class RowData
		{

			public uint ID;

			public SeqListRef<uint> Items;

			public SeqListRef<uint> Reward;
		}
	}
}
