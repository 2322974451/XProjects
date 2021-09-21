using System;

namespace XUtliPoolLib
{
	// Token: 0x02000225 RID: 549
	public class ArgentaDaily : CVSReader
	{
		// Token: 0x06000C44 RID: 3140 RVA: 0x000406B4 File Offset: 0x0003E8B4
		public ArgentaDaily.RowData GetByID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ArgentaDaily.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000C45 RID: 3141 RVA: 0x00040720 File Offset: 0x0003E920
		protected override void ReadLine(XBinaryReader reader)
		{
			ArgentaDaily.RowData rowData = new ArgentaDaily.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Title, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C46 RID: 3142 RVA: 0x000407B4 File Offset: 0x0003E9B4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ArgentaDaily.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000773 RID: 1907
		public ArgentaDaily.RowData[] Table = null;

		// Token: 0x020003B4 RID: 948
		public class RowData
		{
			// Token: 0x04001098 RID: 4248
			public uint ID;

			// Token: 0x04001099 RID: 4249
			public SeqListRef<uint> Reward;

			// Token: 0x0400109A RID: 4250
			public string Description;

			// Token: 0x0400109B RID: 4251
			public string Title;
		}
	}
}
