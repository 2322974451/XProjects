using System;

namespace XUtliPoolLib
{

	public class WeekEnd4v4List : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			WeekEnd4v4List.RowData rowData = new WeekEnd4v4List.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Index, CVSReader.uintParse);
			this.columnno = 1;
			rowData.DropItems.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Rule, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.TexturePath, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.ReviveSeconds, CVSReader.uintParse);
			this.columnno = 7;
			rowData.RankPoint.Read(reader, this.m_DataHandler);
			this.columnno = 9;
			rowData.LoseDrop.Read(reader, this.m_DataHandler);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.MaxTime, CVSReader.uintParse);
			this.columnno = 12;
			base.Read<uint>(reader, ref rowData.RewardTimes, CVSReader.uintParse);
			this.columnno = 13;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new WeekEnd4v4List.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public WeekEnd4v4List.RowData[] Table = null;

		public class RowData
		{

			public uint ID;

			public uint Index;

			public SeqListRef<uint> DropItems;

			public string Name;

			public string Rule;

			public uint SceneID;

			public string TexturePath;

			public uint ReviveSeconds;

			public SeqListRef<uint> RankPoint;

			public SeqListRef<uint> LoseDrop;

			public uint MaxTime;

			public uint RewardTimes;
		}
	}
}
