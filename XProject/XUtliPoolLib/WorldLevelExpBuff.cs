using System;

namespace XUtliPoolLib
{
	// Token: 0x02000182 RID: 386
	public class WorldLevelExpBuff : CVSReader
	{
		// Token: 0x0600085F RID: 2143 RVA: 0x0002C230 File Offset: 0x0002A430
		protected override void ReadLine(XBinaryReader reader)
		{
			WorldLevelExpBuff.RowData rowData = new WorldLevelExpBuff.RowData();
			base.Read<uint>(reader, ref rowData.WorldLevel, CVSReader.uintParse);
			this.columnno = 0;
			rowData.Level.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<double>(reader, ref rowData.ExpBuff, CVSReader.doubleParse);
			this.columnno = 2;
			base.Read<double>(reader, ref rowData.BackExpBuff, CVSReader.doubleParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.BackflowLevel, CVSReader.uintParse);
			this.columnno = 4;
			rowData.BackBattleBuff.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x0002C2F8 File Offset: 0x0002A4F8
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new WorldLevelExpBuff.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003CE RID: 974
		public WorldLevelExpBuff.RowData[] Table = null;

		// Token: 0x02000381 RID: 897
		public class RowData
		{
			// Token: 0x04000F04 RID: 3844
			public uint WorldLevel;

			// Token: 0x04000F05 RID: 3845
			public SeqRef<uint> Level;

			// Token: 0x04000F06 RID: 3846
			public double ExpBuff;

			// Token: 0x04000F07 RID: 3847
			public double BackExpBuff;

			// Token: 0x04000F08 RID: 3848
			public uint BackflowLevel;

			// Token: 0x04000F09 RID: 3849
			public SeqRef<uint> BackBattleBuff;
		}
	}
}
