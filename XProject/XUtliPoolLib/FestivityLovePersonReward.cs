using System;

namespace XUtliPoolLib
{

	public class FestivityLovePersonReward : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			FestivityLovePersonReward.RowData rowData = new FestivityLovePersonReward.RowData();
			base.Read<uint>(reader, ref rowData.LoveScore, CVSReader.uintParse);
			this.columnno = 0;
			rowData.LoveReward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FestivityLovePersonReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FestivityLovePersonReward.RowData[] Table = null;

		public class RowData
		{

			public uint LoveScore;

			public SeqListRef<uint> LoveReward;
		}
	}
}
