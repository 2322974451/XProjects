using System;

namespace XUtliPoolLib
{
	// Token: 0x02000223 RID: 547
	public class NestStarReward : CVSReader
	{
		// Token: 0x06000C3E RID: 3134 RVA: 0x00040510 File Offset: 0x0003E710
		protected override void ReadLine(XBinaryReader reader)
		{
			NestStarReward.RowData rowData = new NestStarReward.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Stars, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.IsHadTittle, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Tittle, CVSReader.stringParse);
			this.columnno = 3;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C3F RID: 3135 RVA: 0x000405BC File Offset: 0x0003E7BC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new NestStarReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000771 RID: 1905
		public NestStarReward.RowData[] Table = null;

		// Token: 0x020003B2 RID: 946
		public class RowData
		{
			// Token: 0x04001090 RID: 4240
			public uint Type;

			// Token: 0x04001091 RID: 4241
			public uint Stars;

			// Token: 0x04001092 RID: 4242
			public uint IsHadTittle;

			// Token: 0x04001093 RID: 4243
			public string Tittle;

			// Token: 0x04001094 RID: 4244
			public SeqListRef<uint> Reward;
		}
	}
}
