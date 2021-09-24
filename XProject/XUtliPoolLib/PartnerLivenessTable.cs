using System;

namespace XUtliPoolLib
{

	public class PartnerLivenessTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			PartnerLivenessTable.RowData rowData = new PartnerLivenessTable.RowData();
			base.Read<uint>(reader, ref rowData.liveness, CVSReader.uintParse);
			this.columnno = 0;
			rowData.level.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.viewabledrop.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.index, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.boxPic, CVSReader.stringParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PartnerLivenessTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PartnerLivenessTable.RowData[] Table = null;

		public class RowData
		{

			public uint liveness;

			public SeqRef<uint> level;

			public SeqListRef<uint> viewabledrop;

			public uint index;

			public string boxPic;
		}
	}
}
