using System;

namespace XUtliPoolLib
{

	public class CookingLevel : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			CookingLevel.RowData rowData = new CookingLevel.RowData();
			base.Read<uint>(reader, ref rowData.CookLevel, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Experiences, CVSReader.uintParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CookingLevel.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public CookingLevel.RowData[] Table = null;

		public class RowData
		{

			public uint CookLevel;

			public uint Experiences;
		}
	}
}
