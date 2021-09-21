using System;

namespace XUtliPoolLib
{
	// Token: 0x0200010A RID: 266
	public class GuildCheckinBoxTable : CVSReader
	{
		// Token: 0x0600069C RID: 1692 RVA: 0x000202D4 File Offset: 0x0001E4D4
		public GuildCheckinBoxTable.RowData GetByprocess(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildCheckinBoxTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].process == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x00020340 File Offset: 0x0001E540
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildCheckinBoxTable.RowData rowData = new GuildCheckinBoxTable.RowData();
			base.Read<uint>(reader, ref rowData.process, CVSReader.uintParse);
			this.columnno = 0;
			rowData.viewabledrop.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x000203A0 File Offset: 0x0001E5A0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildCheckinBoxTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000356 RID: 854
		public GuildCheckinBoxTable.RowData[] Table = null;

		// Token: 0x02000309 RID: 777
		public class RowData
		{
			// Token: 0x04000B49 RID: 2889
			public uint process;

			// Token: 0x04000B4A RID: 2890
			public SeqListRef<uint> viewabledrop;
		}
	}
}
