using System;

namespace XUtliPoolLib
{

	public class DargonReward : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			DargonReward.RowData rowData = new DargonReward.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Achievement, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Explanation, CVSReader.stringParse);
			this.columnno = 2;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.ICON, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.DesignationName, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.SortID, CVSReader.intParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DargonReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public DargonReward.RowData[] Table = null;

		public class RowData
		{

			public int ID;

			public string Achievement;

			public string Explanation;

			public SeqListRef<int> Reward;

			public string ICON;

			public string DesignationName;

			public int SortID;
		}
	}
}
