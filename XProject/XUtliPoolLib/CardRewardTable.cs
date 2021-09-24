using System;

namespace XUtliPoolLib
{

	public class CardRewardTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			CardRewardTable.RowData rowData = new CardRewardTable.RowData();
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.point, CVSReader.uintParse);
			this.columnno = 4;
			rowData.matchreward.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			rowData.jokerreward.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CardRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public CardRewardTable.RowData[] Table = null;

		public class RowData
		{

			public SeqListRef<uint> reward;

			public uint point;

			public SeqListRef<uint> matchreward;

			public SeqListRef<uint> jokerreward;
		}
	}
}
