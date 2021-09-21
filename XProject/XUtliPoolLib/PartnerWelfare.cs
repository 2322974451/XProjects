using System;

namespace XUtliPoolLib
{
	// Token: 0x02000137 RID: 311
	public class PartnerWelfare : CVSReader
	{
		// Token: 0x0600074A RID: 1866 RVA: 0x00024A08 File Offset: 0x00022C08
		public PartnerWelfare.RowData GetById(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PartnerWelfare.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].Id == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x00024A74 File Offset: 0x00022C74
		protected override void ReadLine(XBinaryReader reader)
		{
			PartnerWelfare.RowData rowData = new PartnerWelfare.RowData();
			base.Read<uint>(reader, ref rowData.Id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ContentTxt, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x00024AD4 File Offset: 0x00022CD4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PartnerWelfare.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000383 RID: 899
		public PartnerWelfare.RowData[] Table = null;

		// Token: 0x02000336 RID: 822
		public class RowData
		{
			// Token: 0x04000C94 RID: 3220
			public uint Id;

			// Token: 0x04000C95 RID: 3221
			public string ContentTxt;
		}
	}
}
