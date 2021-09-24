using System;

namespace XUtliPoolLib
{

	public class BuyGoldTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			BuyGoldTable.RowData rowData = new BuyGoldTable.RowData();
			base.Read<long>(reader, ref rowData.Gold, CVSReader.longParse);
			this.columnno = 1;
			base.ReadArray<int>(reader, ref rowData.DragonCoinCost, CVSReader.intParse);
			this.columnno = 2;
			base.ReadArray<int>(reader, ref rowData.DiamondCost, CVSReader.intParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BuyGoldTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public BuyGoldTable.RowData[] Table = null;

		public class RowData
		{

			public long Gold;

			public int[] DragonCoinCost;

			public int[] DiamondCost;
		}
	}
}
