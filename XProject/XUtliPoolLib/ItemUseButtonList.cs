using System;

namespace XUtliPoolLib
{

	public class ItemUseButtonList : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			ItemUseButtonList.RowData rowData = new ItemUseButtonList.RowData();
			base.Read<uint>(reader, ref rowData.ItemID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ButtonName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.SystemID, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.TypeID, CVSReader.uintParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ItemUseButtonList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ItemUseButtonList.RowData[] Table = null;

		public class RowData
		{

			public uint ItemID;

			public string ButtonName;

			public uint SystemID;

			public uint TypeID;
		}
	}
}
