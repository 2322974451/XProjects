using System;

namespace XUtliPoolLib
{

	public class FightDesignation : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			FightDesignation.RowData rowData = new FightDesignation.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Designation, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Effect, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Color, CVSReader.stringParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FightDesignation.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FightDesignation.RowData[] Table = null;

		public class RowData
		{

			public uint ID;

			public string Designation;

			public string Effect;

			public string Color;
		}
	}
}
