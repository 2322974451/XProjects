using System;

namespace XUtliPoolLib
{

	public class BuyDragonCoin : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			BuyDragonCoin.RowData rowData = new BuyDragonCoin.RowData();
			base.Read<long>(reader, ref rowData.DragonCoin, CVSReader.longParse);
			this.columnno = 1;
			base.ReadArray<int>(reader, ref rowData.DiamondCost, CVSReader.intParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BuyDragonCoin.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public BuyDragonCoin.RowData[] Table = null;

		public class RowData
		{

			public long DragonCoin;

			public int[] DiamondCost;
		}
	}
}
