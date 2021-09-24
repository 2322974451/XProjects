using System;

namespace XUtliPoolLib
{

	public class FashionEnhanceFx : CVSReader
	{

		public FashionEnhanceFx.RowData GetByItemID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FashionEnhanceFx.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ItemID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			FashionEnhanceFx.RowData rowData = new FashionEnhanceFx.RowData();
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<string>(reader, ref rowData.Fx1, CVSReader.stringParse);
			this.columnno = 1;
			base.ReadArray<string>(reader, ref rowData.Fx2, CVSReader.stringParse);
			this.columnno = 2;
			base.ReadArray<string>(reader, ref rowData.Fx3, CVSReader.stringParse);
			this.columnno = 3;
			base.ReadArray<string>(reader, ref rowData.Fx4, CVSReader.stringParse);
			this.columnno = 4;
			base.ReadArray<string>(reader, ref rowData.Fx5, CVSReader.stringParse);
			this.columnno = 5;
			base.ReadArray<string>(reader, ref rowData.Fx6, CVSReader.stringParse);
			this.columnno = 6;
			base.ReadArray<string>(reader, ref rowData.Fx7, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadArray<string>(reader, ref rowData.Fx8, CVSReader.stringParse);
			this.columnno = 8;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FashionEnhanceFx.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FashionEnhanceFx.RowData[] Table = null;

		public class RowData
		{

			public int ItemID;

			public string[] Fx1;

			public string[] Fx2;

			public string[] Fx3;

			public string[] Fx4;

			public string[] Fx5;

			public string[] Fx6;

			public string[] Fx7;

			public string[] Fx8;
		}
	}
}
