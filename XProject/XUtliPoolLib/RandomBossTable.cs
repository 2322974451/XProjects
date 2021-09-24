using System;

namespace XUtliPoolLib
{

	public class RandomBossTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			RandomBossTable.RowData rowData = new RandomBossTable.RowData();
			base.Read<int>(reader, ref rowData.RandomID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.EntityID, CVSReader.intParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RandomBossTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public RandomBossTable.RowData[] Table = null;

		public class RowData
		{

			public int RandomID;

			public int EntityID;
		}
	}
}
