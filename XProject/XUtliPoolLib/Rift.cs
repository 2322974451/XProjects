using System;

namespace XUtliPoolLib
{
	// Token: 0x02000266 RID: 614
	public class Rift : CVSReader
	{
		// Token: 0x06000D32 RID: 3378 RVA: 0x00045A74 File Offset: 0x00043C74
		protected override void ReadLine(XBinaryReader reader)
		{
			Rift.RowData rowData = new Rift.RowData();
			base.Read<int>(reader, ref rowData.id, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.floor, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.attack, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.hp, CVSReader.intParse);
			this.columnno = 3;
			rowData.weekfirstpass.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.weekcommonpass.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.buffcounts, CVSReader.intParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.RecommendPower, CVSReader.uintParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D33 RID: 3379 RVA: 0x00045B70 File Offset: 0x00043D70
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new Rift.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007B4 RID: 1972
		public Rift.RowData[] Table = null;

		// Token: 0x020003F5 RID: 1013
		public class RowData
		{
			// Token: 0x04001201 RID: 4609
			public int id;

			// Token: 0x04001202 RID: 4610
			public int floor;

			// Token: 0x04001203 RID: 4611
			public int attack;

			// Token: 0x04001204 RID: 4612
			public int hp;

			// Token: 0x04001205 RID: 4613
			public SeqListRef<uint> weekfirstpass;

			// Token: 0x04001206 RID: 4614
			public SeqListRef<uint> weekcommonpass;

			// Token: 0x04001207 RID: 4615
			public int buffcounts;

			// Token: 0x04001208 RID: 4616
			public uint RecommendPower;
		}
	}
}
