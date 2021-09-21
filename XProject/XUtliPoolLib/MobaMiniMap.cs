using System;

namespace XUtliPoolLib
{
	// Token: 0x0200023D RID: 573
	public class MobaMiniMap : CVSReader
	{
		// Token: 0x06000C9D RID: 3229 RVA: 0x00042594 File Offset: 0x00040794
		public MobaMiniMap.RowData GetByPosIndex(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			MobaMiniMap.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchPosIndex(key);
			}
			return result;
		}

		// Token: 0x06000C9E RID: 3230 RVA: 0x000425CC File Offset: 0x000407CC
		private MobaMiniMap.RowData BinarySearchPosIndex(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			MobaMiniMap.RowData rowData;
			MobaMiniMap.RowData rowData2;
			MobaMiniMap.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.PosIndex == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.PosIndex == key;
				if (flag2)
				{
					goto Block_2;
				}
				bool flag3 = num2 - num <= 1;
				if (flag3)
				{
					goto Block_3;
				}
				int num3 = num + (num2 - num) / 2;
				rowData3 = this.Table[num3];
				bool flag4 = rowData3.PosIndex.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.PosIndex.CompareTo(key) < 0;
					if (!flag5)
					{
						goto IL_B1;
					}
					num = num3;
				}
				if (num >= num2)
				{
					goto Block_6;
				}
			}
			return rowData;
			Block_2:
			return rowData2;
			Block_3:
			return null;
			IL_B1:
			return rowData3;
			Block_6:
			return null;
		}

		// Token: 0x06000C9F RID: 3231 RVA: 0x000426A8 File Offset: 0x000408A8
		protected override void ReadLine(XBinaryReader reader)
		{
			MobaMiniMap.RowData rowData = new MobaMiniMap.RowData();
			base.Read<uint>(reader, ref rowData.PosIndex, CVSReader.uintParse);
			this.columnno = 0;
			rowData.Position.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.ReadArray<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CA0 RID: 3232 RVA: 0x00042720 File Offset: 0x00040920
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new MobaMiniMap.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400078B RID: 1931
		public MobaMiniMap.RowData[] Table = null;

		// Token: 0x020003CC RID: 972
		public class RowData
		{
			// Token: 0x0400111C RID: 4380
			public uint PosIndex;

			// Token: 0x0400111D RID: 4381
			public SeqRef<float> Position;

			// Token: 0x0400111E RID: 4382
			public string[] Icon;
		}
	}
}
