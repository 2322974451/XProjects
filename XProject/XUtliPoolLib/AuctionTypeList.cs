using System;

namespace XUtliPoolLib
{

	public class AuctionTypeList : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			AuctionTypeList.RowData rowData = new AuctionTypeList.RowData();
			base.Read<int>(reader, ref rowData.id, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.pretype, CVSReader.intParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new AuctionTypeList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public AuctionTypeList.RowData[] Table = null;

		public class RowData
		{

			public int id;

			public string name;

			public int pretype;
		}
	}
}
