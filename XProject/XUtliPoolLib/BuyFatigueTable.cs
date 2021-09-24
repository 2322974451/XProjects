using System;

namespace XUtliPoolLib
{

	public class BuyFatigueTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			BuyFatigueTable.RowData rowData = new BuyFatigueTable.RowData();
			base.Read<int>(reader, ref rowData.FatigueID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Value, CVSReader.intParse);
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
				this.Table = new BuyFatigueTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public BuyFatigueTable.RowData[] Table = null;

		public class RowData
		{

			public int FatigueID;

			public int Value;

			public int[] DragonCoinCost;

			public int[] DiamondCost;
		}
	}
}
