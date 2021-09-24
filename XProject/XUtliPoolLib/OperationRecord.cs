using System;

namespace XUtliPoolLib
{

	public class OperationRecord : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			OperationRecord.RowData rowData = new OperationRecord.RowData();
			base.Read<string>(reader, ref rowData.WindowName, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.RecordID, CVSReader.uintParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new OperationRecord.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public OperationRecord.RowData[] Table = null;

		public class RowData
		{

			public string WindowName;

			public uint RecordID;
		}
	}
}
