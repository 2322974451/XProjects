using System;

namespace XUtliPoolLib
{

	public class PayGiftTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			PayGiftTable.RowData rowData = new PayGiftTable.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ParamID, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.ItemID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.LimitCount, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.Price, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PayGiftTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PayGiftTable.RowData[] Table = null;

		public class RowData
		{

			public uint ID;

			public string ParamID;

			public uint ItemID;

			public uint LimitCount;

			public uint Price;

			public string Name;

			public string Desc;
		}
	}
}
