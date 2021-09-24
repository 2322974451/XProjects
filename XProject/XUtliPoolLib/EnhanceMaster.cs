using System;

namespace XUtliPoolLib
{

	public class EnhanceMaster : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			EnhanceMaster.RowData rowData = new EnhanceMaster.RowData();
			base.Read<short>(reader, ref rowData.ProfessionId, CVSReader.shortParse);
			this.columnno = 0;
			base.Read<short>(reader, ref rowData.TotalEnhanceLevel, CVSReader.shortParse);
			this.columnno = 1;
			rowData.Attribute.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new EnhanceMaster.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public EnhanceMaster.RowData[] Table = null;

		public class RowData
		{

			public short ProfessionId;

			public short TotalEnhanceLevel;

			public SeqListRef<uint> Attribute;
		}
	}
}
