using System;

namespace XUtliPoolLib
{
	// Token: 0x0200024C RID: 588
	public class BattleFieldPointReward : CVSReader
	{
		// Token: 0x06000CD6 RID: 3286 RVA: 0x00043804 File Offset: 0x00041A04
		protected override void ReadLine(XBinaryReader reader)
		{
			BattleFieldPointReward.RowData rowData = new BattleFieldPointReward.RowData();
			rowData.levelrange.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.point, CVSReader.intParse);
			this.columnno = 1;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.count, CVSReader.uintParse);
			this.columnno = 4;
			rowData.pointseg.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CD7 RID: 3287 RVA: 0x000438CC File Offset: 0x00041ACC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BattleFieldPointReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400079A RID: 1946
		public BattleFieldPointReward.RowData[] Table = null;

		// Token: 0x020003DB RID: 987
		public class RowData
		{
			// Token: 0x0400115B RID: 4443
			public SeqRef<int> levelrange;

			// Token: 0x0400115C RID: 4444
			public int point;

			// Token: 0x0400115D RID: 4445
			public SeqListRef<int> reward;

			// Token: 0x0400115E RID: 4446
			public uint id;

			// Token: 0x0400115F RID: 4447
			public uint count;

			// Token: 0x04001160 RID: 4448
			public SeqRef<uint> pointseg;
		}
	}
}
