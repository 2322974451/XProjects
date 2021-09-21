using System;

namespace XUtliPoolLib
{
	// Token: 0x0200010B RID: 267
	public class GuildCheckinTable : CVSReader
	{
		// Token: 0x060006A0 RID: 1696 RVA: 0x000203E0 File Offset: 0x0001E5E0
		public GuildCheckinTable.RowData GetBytype(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildCheckinTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].type == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x0002044C File Offset: 0x0001E64C
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildCheckinTable.RowData rowData = new GuildCheckinTable.RowData();
			base.Read<uint>(reader, ref rowData.type, CVSReader.uintParse);
			this.columnno = 0;
			rowData.consume.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.process, CVSReader.uintParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x000204E0 File Offset: 0x0001E6E0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildCheckinTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000357 RID: 855
		public GuildCheckinTable.RowData[] Table = null;

		// Token: 0x0200030A RID: 778
		public class RowData
		{
			// Token: 0x04000B4B RID: 2891
			public uint type;

			// Token: 0x04000B4C RID: 2892
			public SeqRef<uint> consume;

			// Token: 0x04000B4D RID: 2893
			public SeqRef<uint> reward;

			// Token: 0x04000B4E RID: 2894
			public uint process;
		}
	}
}
