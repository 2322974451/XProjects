using System;

namespace XUtliPoolLib
{

	public class MultiActivityList : CVSReader
	{

		public MultiActivityList.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			MultiActivityList.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ID == key;
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
			MultiActivityList.RowData rowData = new MultiActivityList.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			rowData.OpenDayTime.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.GuildLevel, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.DayCountMax, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.RewardTips, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.OpenDayTips, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<bool>(reader, ref rowData.NeedOpenAgain, CVSReader.boolParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.OpenServerWeek, CVSReader.uintParse);
			this.columnno = 12;
			rowData.DropItems.Read(reader, this.m_DataHandler);
			this.columnno = 14;
			base.Read<bool>(reader, ref rowData.HadShop, CVSReader.boolParse);
			this.columnno = 15;
			base.Read<string>(reader, ref rowData.AtlasPath, CVSReader.stringParse);
			this.columnno = 17;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new MultiActivityList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public MultiActivityList.RowData[] Table = null;

		public class RowData
		{

			public int ID;

			public string Name;

			public SeqListRef<uint> OpenDayTime;

			public uint GuildLevel;

			public int DayCountMax;

			public int SystemID;

			public string RewardTips;

			public string OpenDayTips;

			public string Icon;

			public bool NeedOpenAgain;

			public uint OpenServerWeek;

			public SeqListRef<uint> DropItems;

			public bool HadShop;

			public string AtlasPath;
		}
	}
}
