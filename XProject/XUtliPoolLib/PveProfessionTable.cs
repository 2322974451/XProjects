using System;

namespace XUtliPoolLib
{

	public class PveProfessionTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			PveProfessionTable.RowData rowData = new PveProfessionTable.RowData();
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<short>(reader, ref rowData.ProfessionID, CVSReader.shortParse);
			this.columnno = 14;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PveProfessionTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PveProfessionTable.RowData[] Table = null;

		public class RowData
		{

			public uint SceneID;

			public short ProfessionID;
		}
	}
}
