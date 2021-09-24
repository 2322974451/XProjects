using System;

namespace XUtliPoolLib
{

	public class DropList : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			DropList.RowData rowData = new DropList.RowData();
			base.Read<int>(reader, ref rowData.DropID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.ItemCount, CVSReader.intParse);
			this.columnno = 2;
			base.Read<bool>(reader, ref rowData.ItemBind, CVSReader.boolParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DropList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public DropList.RowData[] Table = null;

		public class RowData
		{

			public int DropID;

			public int ItemID;

			public int ItemCount;

			public bool ItemBind;
		}
	}
}
