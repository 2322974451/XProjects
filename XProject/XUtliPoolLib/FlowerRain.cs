using System;

namespace XUtliPoolLib
{

	public class FlowerRain : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			FlowerRain.RowData rowData = new FlowerRain.RowData();
			base.Read<int>(reader, ref rowData.FlowerID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Count, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.EffectPath, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.PlayTime, CVSReader.intParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FlowerRain.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FlowerRain.RowData[] Table = null;

		public class RowData
		{

			public int FlowerID;

			public int Count;

			public string EffectPath;

			public int PlayTime;
		}
	}
}
