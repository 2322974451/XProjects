using System;

namespace XUtliPoolLib
{
	// Token: 0x0200022F RID: 559
	public class CustomSystemRewardTable : CVSReader
	{
		// Token: 0x06000C69 RID: 3177 RVA: 0x00041458 File Offset: 0x0003F658
		protected override void ReadLine(XBinaryReader reader)
		{
			CustomSystemRewardTable.RowData rowData = new CustomSystemRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.wincounts, CVSReader.uintParse);
			this.columnno = 1;
			rowData.rewardshow.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			rowData.boxquickopen.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C6A RID: 3178 RVA: 0x000414EC File Offset: 0x0003F6EC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CustomSystemRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400077D RID: 1917
		public CustomSystemRewardTable.RowData[] Table = null;

		// Token: 0x020003BE RID: 958
		public class RowData
		{
			// Token: 0x040010D8 RID: 4312
			public uint id;

			// Token: 0x040010D9 RID: 4313
			public uint wincounts;

			// Token: 0x040010DA RID: 4314
			public SeqListRef<uint> rewardshow;

			// Token: 0x040010DB RID: 4315
			public SeqRef<uint> boxquickopen;
		}
	}
}
