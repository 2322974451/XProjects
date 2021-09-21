using System;

namespace XUtliPoolLib
{
	// Token: 0x02000269 RID: 617
	public class CampDuelPointReward : CVSReader
	{
		// Token: 0x06000D3B RID: 3387 RVA: 0x00045D54 File Offset: 0x00043F54
		protected override void ReadLine(XBinaryReader reader)
		{
			CampDuelPointReward.RowData rowData = new CampDuelPointReward.RowData();
			base.Read<int>(reader, ref rowData.CampID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Point, CVSReader.intParse);
			this.columnno = 1;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			rowData.EXReward.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D3C RID: 3388 RVA: 0x00045E00 File Offset: 0x00044000
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CampDuelPointReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007B7 RID: 1975
		public CampDuelPointReward.RowData[] Table = null;

		// Token: 0x020003F8 RID: 1016
		public class RowData
		{
			// Token: 0x04001211 RID: 4625
			public int CampID;

			// Token: 0x04001212 RID: 4626
			public int Point;

			// Token: 0x04001213 RID: 4627
			public SeqListRef<int> Reward;

			// Token: 0x04001214 RID: 4628
			public SeqRef<int> EXReward;

			// Token: 0x04001215 RID: 4629
			public string Icon;
		}
	}
}
