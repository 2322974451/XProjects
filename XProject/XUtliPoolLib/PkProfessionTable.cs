using System;

namespace XUtliPoolLib
{

	public class PkProfessionTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			PkProfessionTable.RowData rowData = new PkProfessionTable.RowData();
			base.ReadArray<byte>(reader, ref rowData.SceneType, CVSReader.byteParse);
			this.columnno = 13;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PkProfessionTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PkProfessionTable.RowData[] Table = null;

		public class RowData
		{

			public byte[] SceneType;
		}
	}
}
