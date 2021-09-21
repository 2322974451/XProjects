using System;

namespace XUtliPoolLib
{
	// Token: 0x0200014A RID: 330
	public class PlantSeed : CVSReader
	{
		// Token: 0x0600078A RID: 1930 RVA: 0x000260DC File Offset: 0x000242DC
		public PlantSeed.RowData GetBySeedID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PlantSeed.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SeedID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x00026148 File Offset: 0x00024348
		protected override void ReadLine(XBinaryReader reader)
		{
			PlantSeed.RowData rowData = new PlantSeed.RowData();
			base.Read<uint>(reader, ref rowData.SeedID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SeedName, CVSReader.stringParse);
			this.columnno = 1;
			rowData.PlantID.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.PlantName, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.GrowUpAmount, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.GrowUpAmountPerMinute, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.PredictGrowUpTime, CVSReader.uintParse);
			this.columnno = 10;
			rowData.HarvestPlant.Read(reader, this.m_DataHandler);
			this.columnno = 12;
			rowData.ExtraDropItem.Read(reader, this.m_DataHandler);
			this.columnno = 15;
			base.Read<uint>(reader, ref rowData.IncreaseGrowUpRate, CVSReader.uintParse);
			this.columnno = 17;
			base.Read<uint>(reader, ref rowData.ReduceGrowUpRate, CVSReader.uintParse);
			this.columnno = 18;
			base.Read<uint>(reader, ref rowData.PlantStateCD, CVSReader.uintParse);
			this.columnno = 19;
			base.Read<uint>(reader, ref rowData.BadStateGrowUpRate, CVSReader.uintParse);
			this.columnno = 21;
			rowData.StealAward.Read(reader, this.m_DataHandler);
			this.columnno = 22;
			base.Read<uint>(reader, ref rowData.CanStealMaxTimes, CVSReader.uintParse);
			this.columnno = 27;
			base.Read<uint>(reader, ref rowData.InitUpAmount, CVSReader.uintParse);
			this.columnno = 28;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x0002631C File Offset: 0x0002451C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PlantSeed.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000396 RID: 918
		public PlantSeed.RowData[] Table = null;

		// Token: 0x02000349 RID: 841
		public class RowData
		{
			// Token: 0x04000D08 RID: 3336
			public uint SeedID;

			// Token: 0x04000D09 RID: 3337
			public string SeedName;

			// Token: 0x04000D0A RID: 3338
			public SeqRef<int> PlantID;

			// Token: 0x04000D0B RID: 3339
			public string PlantName;

			// Token: 0x04000D0C RID: 3340
			public uint GrowUpAmount;

			// Token: 0x04000D0D RID: 3341
			public uint GrowUpAmountPerMinute;

			// Token: 0x04000D0E RID: 3342
			public uint PredictGrowUpTime;

			// Token: 0x04000D0F RID: 3343
			public SeqRef<uint> HarvestPlant;

			// Token: 0x04000D10 RID: 3344
			public SeqRef<uint> ExtraDropItem;

			// Token: 0x04000D11 RID: 3345
			public uint IncreaseGrowUpRate;

			// Token: 0x04000D12 RID: 3346
			public uint ReduceGrowUpRate;

			// Token: 0x04000D13 RID: 3347
			public uint PlantStateCD;

			// Token: 0x04000D14 RID: 3348
			public uint BadStateGrowUpRate;

			// Token: 0x04000D15 RID: 3349
			public SeqRef<int> StealAward;

			// Token: 0x04000D16 RID: 3350
			public uint CanStealMaxTimes;

			// Token: 0x04000D17 RID: 3351
			public uint InitUpAmount;
		}
	}
}
