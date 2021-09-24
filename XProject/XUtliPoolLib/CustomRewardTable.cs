using System;

namespace XUtliPoolLib
{

	public class CustomRewardTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			CustomRewardTable.RowData rowData = new CustomRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			rowData.rank.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.rewardshow.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			rowData.boxquickopen.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CustomRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public CustomRewardTable.RowData[] Table = null;

		public class RowData
		{

			public uint id;

			public SeqRef<uint> rank;

			public SeqListRef<uint> rewardshow;

			public SeqRef<uint> boxquickopen;
		}
	}
}
