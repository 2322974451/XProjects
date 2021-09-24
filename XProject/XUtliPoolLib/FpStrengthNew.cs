using System;

namespace XUtliPoolLib
{

	public class FpStrengthNew : CVSReader
	{

		public FpStrengthNew.RowData GetByBQID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FpStrengthNew.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].BQID == key;
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
			FpStrengthNew.RowData rowData = new FpStrengthNew.RowData();
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
			base.Read<int>(reader, ref rowData.ShowLevel, CVSReader.intParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.StarNum, CVSReader.intParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FpStrengthNew.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FpStrengthNew.RowData[] Table = null;

		public class RowData
		{

			public int BQID;

			public int Bqtype;

			public int BQSystem;

			public string BQTips;

			public string BQImageID;

			public int ShowLevel;

			public int StarNum;
		}
	}
}
