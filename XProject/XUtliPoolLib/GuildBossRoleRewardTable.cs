using System;

namespace XUtliPoolLib
{
	// Token: 0x02000106 RID: 262
	public class GuildBossRoleRewardTable : CVSReader
	{
		// Token: 0x06000690 RID: 1680 RVA: 0x0001FFD4 File Offset: 0x0001E1D4
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildBossRoleRewardTable.RowData rowData = new GuildBossRoleRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.BossID, CVSReader.uintParse);
			this.columnno = 0;
			rowData.prestige.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x00020034 File Offset: 0x0001E234
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildBossRoleRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000352 RID: 850
		public GuildBossRoleRewardTable.RowData[] Table = null;

		// Token: 0x02000305 RID: 773
		public class RowData
		{
			// Token: 0x04000B3C RID: 2876
			public uint BossID;

			// Token: 0x04000B3D RID: 2877
			public SeqListRef<uint> prestige;
		}
	}
}
