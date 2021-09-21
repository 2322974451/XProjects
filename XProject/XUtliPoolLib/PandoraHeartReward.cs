using System;

namespace XUtliPoolLib
{
	// Token: 0x02000134 RID: 308
	public class PandoraHeartReward : CVSReader
	{
		// Token: 0x06000740 RID: 1856 RVA: 0x00024740 File Offset: 0x00022940
		protected override void ReadLine(XBinaryReader reader)
		{
			PandoraHeartReward.RowData rowData = new PandoraHeartReward.RowData();
			base.Read<uint>(reader, ref rowData.pandoraid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 1;
			rowData.showlevel.Read(reader, this.m_DataHandler);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x000247B8 File Offset: 0x000229B8
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PandoraHeartReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000380 RID: 896
		public PandoraHeartReward.RowData[] Table = null;

		// Token: 0x02000333 RID: 819
		public class RowData
		{
			// Token: 0x04000C89 RID: 3209
			public uint pandoraid;

			// Token: 0x04000C8A RID: 3210
			public uint itemid;

			// Token: 0x04000C8B RID: 3211
			public SeqRef<uint> showlevel;
		}
	}
}
