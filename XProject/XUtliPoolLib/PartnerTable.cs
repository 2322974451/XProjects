using System;

namespace XUtliPoolLib
{

	public class PartnerTable : CVSReader
	{

		public PartnerTable.RowData GetBylevel(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PartnerTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].level == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			PartnerTable.RowData rowData = new PartnerTable.RowData();
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.degree, CVSReader.uintParse);
			this.columnno = 1;
			rowData.buf.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PartnerTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PartnerTable.RowData[] Table = null;

		public class RowData
		{

			public uint level;

			public uint degree;

			public SeqRef<int> buf;
		}
	}
}
