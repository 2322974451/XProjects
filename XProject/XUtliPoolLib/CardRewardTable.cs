using System;

namespace XUtliPoolLib
{
	// Token: 0x020000BD RID: 189
	public class CardRewardTable : CVSReader
	{
		// Token: 0x06000565 RID: 1381 RVA: 0x0001850C File Offset: 0x0001670C
		protected override void ReadLine(XBinaryReader reader)
		{
			CardRewardTable.RowData rowData = new CardRewardTable.RowData();
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.point, CVSReader.uintParse);
			this.columnno = 4;
			rowData.matchreward.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			rowData.jokerreward.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x000185A0 File Offset: 0x000167A0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CardRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002E3 RID: 739
		public CardRewardTable.RowData[] Table = null;

		// Token: 0x020002BB RID: 699
		public class RowData
		{
			// Token: 0x0400095E RID: 2398
			public SeqListRef<uint> reward;

			// Token: 0x0400095F RID: 2399
			public uint point;

			// Token: 0x04000960 RID: 2400
			public SeqListRef<uint> matchreward;

			// Token: 0x04000961 RID: 2401
			public SeqListRef<uint> jokerreward;
		}
	}
}
