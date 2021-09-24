using System;

namespace XUtliPoolLib
{

	public class GoalAwards : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			GoalAwards.RowData rowData = new GoalAwards.RowData();
			base.Read<uint>(reader, ref rowData.GoalAwardsID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.AwardsIndex, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.GKID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<double>(reader, ref rowData.AwardsValue, CVSReader.doubleParse);
			this.columnno = 3;
			rowData.Awards.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.TitleID, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.Explanation, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.ShowLevel, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.ShowType, CVSReader.uintParse);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GoalAwards.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GoalAwards.RowData[] Table = null;

		public class RowData
		{

			public uint GoalAwardsID;

			public uint AwardsIndex;

			public uint GKID;

			public double AwardsValue;

			public SeqListRef<uint> Awards;

			public uint TitleID;

			public uint Type;

			public string Description;

			public string Explanation;

			public uint ShowLevel;

			public uint ShowType;
		}
	}
}
