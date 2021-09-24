using System;

namespace XUtliPoolLib
{

	public class ActivityListTable : CVSReader
	{

		public ActivityListTable.RowData GetBySysID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ActivityListTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SysID == key;
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
			ActivityListTable.RowData rowData = new ActivityListTable.RowData();
			base.Read<uint>(reader, ref rowData.SysID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Tittle, CVSReader.stringParse);
			this.columnno = 1;
			base.ReadArray<string>(reader, ref rowData.TagNames, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			base.ReadArray<string>(reader, ref rowData.TagName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<bool>(reader, ref rowData.HadShop, CVSReader.boolParse);
			this.columnno = 5;
			rowData.DropItems.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.Describe, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.SortIndex, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.AtlasPath, CVSReader.stringParse);
			this.columnno = 9;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ActivityListTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ActivityListTable.RowData[] Table = null;

		public class RowData
		{

			public uint SysID;

			public string Tittle;

			public string[] TagNames;

			public string Icon;

			public string[] TagName;

			public bool HadShop;

			public SeqListRef<uint> DropItems;

			public string Describe;

			public uint SortIndex;

			public string AtlasPath;
		}
	}
}
