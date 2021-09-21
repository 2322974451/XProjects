using System;

namespace XUtliPoolLib
{
	// Token: 0x0200022E RID: 558
	public class CustomRewardTable : CVSReader
	{
		// Token: 0x06000C66 RID: 3174 RVA: 0x00041384 File Offset: 0x0003F584
		protected override void ReadLine(XBinaryReader reader)
		{
			CustomRewardTable.RowData rowData = new CustomRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			rowData.rank.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.rewardshow.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			rowData.boxquickopen.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x00041418 File Offset: 0x0003F618
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CustomRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400077C RID: 1916
		public CustomRewardTable.RowData[] Table = null;

		// Token: 0x020003BD RID: 957
		public class RowData
		{
			// Token: 0x040010D4 RID: 4308
			public uint id;

			// Token: 0x040010D5 RID: 4309
			public SeqRef<uint> rank;

			// Token: 0x040010D6 RID: 4310
			public SeqListRef<uint> rewardshow;

			// Token: 0x040010D7 RID: 4311
			public SeqRef<uint> boxquickopen;
		}
	}
}
