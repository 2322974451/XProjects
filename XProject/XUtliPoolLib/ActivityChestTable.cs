using System;

namespace XUtliPoolLib
{

	public class ActivityChestTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			ActivityChestTable.RowData rowData = new ActivityChestTable.RowData();
			base.Read<uint>(reader, ref rowData.chest, CVSReader.uintParse);
			this.columnno = 0;
			rowData.level.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.viewabledrop.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ActivityChestTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ActivityChestTable.RowData[] Table = null;

		public class RowData
		{

			public uint chest;

			public SeqRef<uint> level;

			public SeqListRef<uint> viewabledrop;
		}
	}
}
