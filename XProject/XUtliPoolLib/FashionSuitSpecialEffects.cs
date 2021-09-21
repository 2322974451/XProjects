using System;

namespace XUtliPoolLib
{
	// Token: 0x02000260 RID: 608
	public class FashionSuitSpecialEffects : CVSReader
	{
		// Token: 0x06000D1C RID: 3356 RVA: 0x000451F8 File Offset: 0x000433F8
		public FashionSuitSpecialEffects.RowData GetBysuitid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FashionSuitSpecialEffects.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchsuitid(key);
			}
			return result;
		}

		// Token: 0x06000D1D RID: 3357 RVA: 0x00045230 File Offset: 0x00043430
		private FashionSuitSpecialEffects.RowData BinarySearchsuitid(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			FashionSuitSpecialEffects.RowData rowData;
			FashionSuitSpecialEffects.RowData rowData2;
			FashionSuitSpecialEffects.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.suitid == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.suitid == key;
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
				bool flag4 = rowData3.suitid.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.suitid.CompareTo(key) < 0;
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

		// Token: 0x06000D1E RID: 3358 RVA: 0x0004530C File Offset: 0x0004350C
		protected override void ReadLine(XBinaryReader reader)
		{
			FashionSuitSpecialEffects.RowData rowData = new FashionSuitSpecialEffects.RowData();
			base.Read<uint>(reader, ref rowData.suitid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.specialeffectsid, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Fx1, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Fx2, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Fx3, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Fx4, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Fx5, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.Fx6, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.Fx7, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.Fx8, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 11;
			base.ReadArray<uint>(reader, ref rowData.FashionList, CVSReader.uintParse);
			this.columnno = 12;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D1F RID: 3359 RVA: 0x0004548C File Offset: 0x0004368C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FashionSuitSpecialEffects.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007AE RID: 1966
		public FashionSuitSpecialEffects.RowData[] Table = null;

		// Token: 0x020003EF RID: 1007
		public class RowData
		{
			// Token: 0x040011D9 RID: 4569
			public uint suitid;

			// Token: 0x040011DA RID: 4570
			public uint specialeffectsid;

			// Token: 0x040011DB RID: 4571
			public string Fx1;

			// Token: 0x040011DC RID: 4572
			public string Fx2;

			// Token: 0x040011DD RID: 4573
			public string Fx3;

			// Token: 0x040011DE RID: 4574
			public string Fx4;

			// Token: 0x040011DF RID: 4575
			public string Fx5;

			// Token: 0x040011E0 RID: 4576
			public string Fx6;

			// Token: 0x040011E1 RID: 4577
			public string Fx7;

			// Token: 0x040011E2 RID: 4578
			public string Fx8;

			// Token: 0x040011E3 RID: 4579
			public string Name;

			// Token: 0x040011E4 RID: 4580
			public string Icon;

			// Token: 0x040011E5 RID: 4581
			public uint[] FashionList;
		}
	}
}
