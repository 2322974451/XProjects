using System;

namespace XUtliPoolLib
{

	public class FpStrengthenTable : CVSReader
	{

		public FpStrengthenTable.RowData GetByBQID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FpStrengthenTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchBQID(key);
			}
			return result;
		}

		private FpStrengthenTable.RowData BinarySearchBQID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			FpStrengthenTable.RowData rowData;
			FpStrengthenTable.RowData rowData2;
			FpStrengthenTable.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.BQID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.BQID == key;
				if (flag2)
				{
					goto Block_2;
				}
				bool flag3 = num2 - num <= 1;
				if (flag3)
				{
					goto Block_3;
				}
				int num3 = num + (num2 - num) / 2;
				rowData3 = this.Table[num3];
				bool flag4 = rowData3.BQID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.BQID.CompareTo(key) < 0;
					if (!flag5)
					{
						goto IL_B1;
					}
					num = num3;
				}
				if (num >= num2)
				{
					goto Block_6;
				}
			}
			return rowData;
			Block_2:
			return rowData2;
			Block_3:
			return null;
			IL_B1:
			return rowData3;
			Block_6:
			return null;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			FpStrengthenTable.RowData rowData = new FpStrengthenTable.RowData();
			base.Read<int>(reader, ref rowData.BQID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Bqtype, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.BQSystem, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.BQTips, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.BQImageID, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.BQName, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.ShowLevel, CVSReader.intParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FpStrengthenTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FpStrengthenTable.RowData[] Table = null;

		public class RowData
		{

			public int BQID;

			public int Bqtype;

			public int BQSystem;

			public string BQTips;

			public string BQImageID;

			public string BQName;

			public int ShowLevel;
		}
	}
}
