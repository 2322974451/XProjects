using System;

namespace XUtliPoolLib
{

	public class CardsGroupList : CVSReader
	{

		public CardsGroupList.RowData GetByGroupId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			CardsGroupList.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].GroupId == key;
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
			CardsGroupList.RowData rowData = new CardsGroupList.RowData();
			base.Read<uint>(reader, ref rowData.GroupId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.ShowLevel, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.OpenLevel, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.ShowUp, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Detail, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.GroupName, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.MapID, CVSReader.uintParse);
			this.columnno = 6;
			base.ReadArray<uint>(reader, ref rowData.BreakLevel, CVSReader.uintParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CardsGroupList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public CardsGroupList.RowData[] Table = null;

		public class RowData
		{

			public uint GroupId;

			public uint ShowLevel;

			public uint OpenLevel;

			public string ShowUp;

			public string Detail;

			public string GroupName;

			public uint MapID;

			public uint[] BreakLevel;
		}
	}
}
