using System;

namespace XUtliPoolLib
{
	// Token: 0x0200022D RID: 557
	public class GuildCampPartyReward : CVSReader
	{
		// Token: 0x06000C63 RID: 3171 RVA: 0x000412CC File Offset: 0x0003F4CC
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildCampPartyReward.RowData rowData = new GuildCampPartyReward.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			rowData.Items.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C64 RID: 3172 RVA: 0x00041344 File Offset: 0x0003F544
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildCampPartyReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400077B RID: 1915
		public GuildCampPartyReward.RowData[] Table = null;

		// Token: 0x020003BC RID: 956
		public class RowData
		{
			// Token: 0x040010D1 RID: 4305
			public uint ID;

			// Token: 0x040010D2 RID: 4306
			public SeqListRef<uint> Items;

			// Token: 0x040010D3 RID: 4307
			public SeqListRef<uint> Reward;
		}
	}
}
