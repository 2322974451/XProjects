using System;

namespace XUtliPoolLib
{

	public class SpriteLevel : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			SpriteLevel.RowData rowData = new SpriteLevel.RowData();
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Quality, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.Exp, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<double>(reader, ref rowData.Ratio, CVSReader.doubleParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SpriteLevel.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public SpriteLevel.RowData[] Table = null;

		public class RowData
		{

			public uint Level;

			public uint Quality;

			public uint Exp;

			public double Ratio;
		}
	}
}
