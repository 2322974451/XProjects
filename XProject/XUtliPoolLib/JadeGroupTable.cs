using System;

namespace XUtliPoolLib
{

	public class JadeGroupTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			JadeGroupTable.RowData rowData = new JadeGroupTable.RowData();
			base.Read<uint>(reader, ref rowData.JadeID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.GroupID, CVSReader.uintParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new JadeGroupTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public JadeGroupTable.RowData[] Table = null;

		public class RowData
		{

			public uint JadeID;

			public uint GroupID;
		}
	}
}
