using System;

namespace XUtliPoolLib
{

	public class CustomSystemRewardTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			CustomSystemRewardTable.RowData rowData = new CustomSystemRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.wincounts, CVSReader.uintParse);
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
				this.Table = new CustomSystemRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public CustomSystemRewardTable.RowData[] Table = null;

		public class RowData
		{

			public uint id;

			public uint wincounts;

			public SeqListRef<uint> rewardshow;

			public SeqRef<uint> boxquickopen;
		}
	}
}
