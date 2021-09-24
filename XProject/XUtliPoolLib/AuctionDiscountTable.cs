using System;

namespace XUtliPoolLib
{

	public class AuctionDiscountTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			AuctionDiscountTable.RowData rowData = new AuctionDiscountTable.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Group, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<float>(reader, ref rowData.Discount, CVSReader.floatParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new AuctionDiscountTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public AuctionDiscountTable.RowData[] Table = null;

		public class RowData
		{

			public uint Type;

			public uint Group;

			public float Discount;
		}
	}
}
