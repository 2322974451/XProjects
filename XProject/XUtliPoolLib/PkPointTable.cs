using System;

namespace XUtliPoolLib
{

	public class PkPointTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			PkPointTable.RowData rowData = new PkPointTable.RowData();
			base.Read<uint>(reader, ref rowData.point, CVSReader.uintParse);
			this.columnno = 0;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.IconIndex, CVSReader.intParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PkPointTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PkPointTable.RowData[] Table = null;

		public class RowData
		{

			public uint point;

			public SeqListRef<uint> reward;

			public int IconIndex;
		}
	}
}
