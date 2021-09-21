using System;

namespace XUtliPoolLib
{
	// Token: 0x02000103 RID: 259
	public class GuildBonusTable : CVSReader
	{
		// Token: 0x06000682 RID: 1666 RVA: 0x0001FA90 File Offset: 0x0001DC90
		public GuildBonusTable.RowData GetByGuildBonusID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildBonusTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].GuildBonusID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x0001FAFC File Offset: 0x0001DCFC
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildBonusTable.RowData rowData = new GuildBonusTable.RowData();
			base.Read<uint>(reader, ref rowData.GuildBonusID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.GuildBonusName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.GuildBonusDesc, CVSReader.stringParse);
			this.columnno = 3;
			rowData.GuildBonusReward.Read(reader, this.m_DataHandler);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x0001FB90 File Offset: 0x0001DD90
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildBonusTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400034F RID: 847
		public GuildBonusTable.RowData[] Table = null;

		// Token: 0x02000302 RID: 770
		public class RowData
		{
			// Token: 0x04000B2E RID: 2862
			public uint GuildBonusID;

			// Token: 0x04000B2F RID: 2863
			public string GuildBonusName;

			// Token: 0x04000B30 RID: 2864
			public string GuildBonusDesc;

			// Token: 0x04000B31 RID: 2865
			public SeqRef<uint> GuildBonusReward;
		}
	}
}
