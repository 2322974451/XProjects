using System;

namespace XUtliPoolLib
{

	public class PayAileenTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			PayAileenTable.RowData rowData = new PayAileenTable.RowData();
			base.Read<string>(reader, ref rowData.ParamID, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Days, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Price, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.VipLimit, CVSReader.intParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 6;
			base.ReadArray<int>(reader, ref rowData.LevelSealGiftID, CVSReader.intParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.MemberLimit, CVSReader.intParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.ServiceCode, CVSReader.stringParse);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PayAileenTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PayAileenTable.RowData[] Table = null;

		public class RowData
		{

			public string ParamID;

			public int Days;

			public int Price;

			public int VipLimit;

			public string Name;

			public string Desc;

			public int[] LevelSealGiftID;

			public int MemberLimit;

			public string ServiceCode;
		}
	}
}
