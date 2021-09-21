using System;

namespace XUtliPoolLib
{
	// Token: 0x0200016F RID: 367
	public class SpriteEvolution : CVSReader
	{
		// Token: 0x06000817 RID: 2071 RVA: 0x0002A258 File Offset: 0x00028458
		protected override void ReadLine(XBinaryReader reader)
		{
			SpriteEvolution.RowData rowData = new SpriteEvolution.RowData();
			base.Read<uint>(reader, ref rowData.SpriteID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<byte>(reader, ref rowData.Quality, CVSReader.byteParse);
			this.columnno = 1;
			base.Read<byte>(reader, ref rowData.EvolutionLevel, CVSReader.byteParse);
			this.columnno = 2;
			base.Read<byte>(reader, ref rowData.LevelLimit, CVSReader.byteParse);
			this.columnno = 3;
			rowData.EvolutionCost.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.TrainExp.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			rowData.ResetTrainCost.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x0002A338 File Offset: 0x00028538
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SpriteEvolution.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003BB RID: 955
		public SpriteEvolution.RowData[] Table = null;

		// Token: 0x0200036E RID: 878
		public class RowData
		{
			// Token: 0x04000E61 RID: 3681
			public uint SpriteID;

			// Token: 0x04000E62 RID: 3682
			public byte Quality;

			// Token: 0x04000E63 RID: 3683
			public byte EvolutionLevel;

			// Token: 0x04000E64 RID: 3684
			public byte LevelLimit;

			// Token: 0x04000E65 RID: 3685
			public SeqRef<uint> EvolutionCost;

			// Token: 0x04000E66 RID: 3686
			public SeqRef<uint> TrainExp;

			// Token: 0x04000E67 RID: 3687
			public SeqListRef<uint> ResetTrainCost;
		}
	}
}
