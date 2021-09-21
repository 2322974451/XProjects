using System;

namespace XUtliPoolLib
{
	// Token: 0x020000FF RID: 255
	public class GardenBanquetCfg : CVSReader
	{
		// Token: 0x06000672 RID: 1650 RVA: 0x0001F4DC File Offset: 0x0001D6DC
		public GardenBanquetCfg.RowData GetByBanquetID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GardenBanquetCfg.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].BanquetID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x0001F548 File Offset: 0x0001D748
		protected override void ReadLine(XBinaryReader reader)
		{
			GardenBanquetCfg.RowData rowData = new GardenBanquetCfg.RowData();
			base.Read<uint>(reader, ref rowData.BanquetID, CVSReader.uintParse);
			this.columnno = 0;
			rowData.Stuffs.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.BanquetAwards.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.BanquetName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.VoiceOver1Duration, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.VoiceOver2Duration, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.VoiceOver3Duration, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.VoiceOver4Duration, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.VoiceOver1, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.VoiceOver2, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.VoiceOver3, CVSReader.stringParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.VoiceOver4, CVSReader.stringParse);
			this.columnno = 12;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 13;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x0001F6C8 File Offset: 0x0001D8C8
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GardenBanquetCfg.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400034B RID: 843
		public GardenBanquetCfg.RowData[] Table = null;

		// Token: 0x020002FE RID: 766
		public class RowData
		{
			// Token: 0x04000B18 RID: 2840
			public uint BanquetID;

			// Token: 0x04000B19 RID: 2841
			public SeqListRef<uint> Stuffs;

			// Token: 0x04000B1A RID: 2842
			public SeqListRef<uint> BanquetAwards;

			// Token: 0x04000B1B RID: 2843
			public string BanquetName;

			// Token: 0x04000B1C RID: 2844
			public uint VoiceOver1Duration;

			// Token: 0x04000B1D RID: 2845
			public uint VoiceOver2Duration;

			// Token: 0x04000B1E RID: 2846
			public uint VoiceOver3Duration;

			// Token: 0x04000B1F RID: 2847
			public uint VoiceOver4Duration;

			// Token: 0x04000B20 RID: 2848
			public string VoiceOver1;

			// Token: 0x04000B21 RID: 2849
			public string VoiceOver2;

			// Token: 0x04000B22 RID: 2850
			public string VoiceOver3;

			// Token: 0x04000B23 RID: 2851
			public string VoiceOver4;

			// Token: 0x04000B24 RID: 2852
			public string Desc;
		}
	}
}
