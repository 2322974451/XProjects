using System;

namespace XUtliPoolLib
{
	// Token: 0x020000F2 RID: 242
	public class FishInfo : CVSReader
	{
		// Token: 0x06000645 RID: 1605 RVA: 0x0001E62C File Offset: 0x0001C82C
		public FishInfo.RowData GetByFishID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FishInfo.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].FishID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x0001E698 File Offset: 0x0001C898
		protected override void ReadLine(XBinaryReader reader)
		{
			FishInfo.RowData rowData = new FishInfo.RowData();
			base.Read<uint>(reader, ref rowData.FishID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.quality, CVSReader.intParse);
			this.columnno = 2;
			base.Read<bool>(reader, ref rowData.ShowInLevel, CVSReader.boolParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x0001E710 File Offset: 0x0001C910
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FishInfo.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400033E RID: 830
		public FishInfo.RowData[] Table = null;

		// Token: 0x020002F1 RID: 753
		public class RowData
		{
			// Token: 0x04000AD8 RID: 2776
			public uint FishID;

			// Token: 0x04000AD9 RID: 2777
			public int quality;

			// Token: 0x04000ADA RID: 2778
			public bool ShowInLevel;
		}
	}
}
