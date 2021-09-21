using System;

namespace XUtliPoolLib
{
	// Token: 0x02000100 RID: 256
	public class GardenFishConfig : CVSReader
	{
		// Token: 0x06000676 RID: 1654 RVA: 0x0001F708 File Offset: 0x0001D908
		public GardenFishConfig.RowData GetByFishLeve(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GardenFishConfig.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].FishLeve == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x0001F774 File Offset: 0x0001D974
		protected override void ReadLine(XBinaryReader reader)
		{
			GardenFishConfig.RowData rowData = new GardenFishConfig.RowData();
			base.Read<uint>(reader, ref rowData.FishLeve, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Experience, CVSReader.uintParse);
			this.columnno = 1;
			rowData.FishWeight.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.SuccessRate, CVSReader.uintParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x0001F808 File Offset: 0x0001DA08
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GardenFishConfig.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400034C RID: 844
		public GardenFishConfig.RowData[] Table = null;

		// Token: 0x020002FF RID: 767
		public class RowData
		{
			// Token: 0x04000B25 RID: 2853
			public uint FishLeve;

			// Token: 0x04000B26 RID: 2854
			public uint Experience;

			// Token: 0x04000B27 RID: 2855
			public SeqListRef<int> FishWeight;

			// Token: 0x04000B28 RID: 2856
			public uint SuccessRate;
		}
	}
}
