using System;

namespace XUtliPoolLib
{
	// Token: 0x02000136 RID: 310
	public class PartnerTable : CVSReader
	{
		// Token: 0x06000746 RID: 1862 RVA: 0x000248E4 File Offset: 0x00022AE4
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

		// Token: 0x06000747 RID: 1863 RVA: 0x00024950 File Offset: 0x00022B50
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

		// Token: 0x06000748 RID: 1864 RVA: 0x000249C8 File Offset: 0x00022BC8
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

		// Token: 0x04000382 RID: 898
		public PartnerTable.RowData[] Table = null;

		// Token: 0x02000335 RID: 821
		public class RowData
		{
			// Token: 0x04000C91 RID: 3217
			public uint level;

			// Token: 0x04000C92 RID: 3218
			public uint degree;

			// Token: 0x04000C93 RID: 3219
			public SeqRef<int> buf;
		}
	}
}
