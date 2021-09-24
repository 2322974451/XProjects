using System;

namespace XUtliPoolLib
{

	public class RecommendFightNum : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			RecommendFightNum.RowData rowData = new RecommendFightNum.RowData();
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.SystemID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.Total, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.Point, CVSReader.uintParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RecommendFightNum.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public RecommendFightNum.RowData[] Table = null;

		public class RowData
		{

			public uint Level;

			public uint SystemID;

			public uint Total;

			public uint Point;
		}
	}
}
