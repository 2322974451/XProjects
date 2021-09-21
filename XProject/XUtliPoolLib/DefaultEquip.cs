using System;

namespace XUtliPoolLib
{
	// Token: 0x020000D9 RID: 217
	public class DefaultEquip : CVSReader
	{
		// Token: 0x060005E6 RID: 1510 RVA: 0x0001B8A0 File Offset: 0x00019AA0
		public DefaultEquip.RowData GetByProfID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			DefaultEquip.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchProfID(key);
			}
			return result;
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x0001B8D8 File Offset: 0x00019AD8
		private DefaultEquip.RowData BinarySearchProfID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			DefaultEquip.RowData rowData;
			DefaultEquip.RowData rowData2;
			DefaultEquip.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.ProfID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.ProfID == key;
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
				bool flag4 = rowData3.ProfID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.ProfID.CompareTo(key) < 0;
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

		// Token: 0x060005E8 RID: 1512 RVA: 0x0001B9B4 File Offset: 0x00019BB4
		protected override void ReadLine(XBinaryReader reader)
		{
			DefaultEquip.RowData rowData = new DefaultEquip.RowData();
			base.Read<int>(reader, ref rowData.ProfID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Helmet, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Face, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Body, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Leg, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Boots, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Glove, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.Weapon, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadArray<string>(reader, ref rowData.WeaponPoint, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.WingPoint, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.SecondWeapon, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.Wing, CVSReader.stringParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.Tail, CVSReader.stringParse);
			this.columnno = 12;
			base.Read<string>(reader, ref rowData.Decal, CVSReader.stringParse);
			this.columnno = 13;
			base.Read<string>(reader, ref rowData.Hair, CVSReader.stringParse);
			this.columnno = 14;
			base.Read<string>(reader, ref rowData.TailPoint, CVSReader.stringParse);
			this.columnno = 15;
			base.Read<string>(reader, ref rowData.FishingPoint, CVSReader.stringParse);
			this.columnno = 16;
			base.ReadArray<string>(reader, ref rowData.SideWeaponPoint, CVSReader.stringParse);
			this.columnno = 17;
			base.Read<string>(reader, ref rowData.RootPoint, CVSReader.stringParse);
			this.columnno = 18;
			base.Read<byte>(reader, ref rowData.id, CVSReader.byteParse);
			this.columnno = 19;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x0001BBF0 File Offset: 0x00019DF0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DefaultEquip.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000325 RID: 805
		public DefaultEquip.RowData[] Table = null;

		// Token: 0x020002D8 RID: 728
		public class RowData
		{
			// Token: 0x040009E5 RID: 2533
			public int ProfID;

			// Token: 0x040009E6 RID: 2534
			public string Helmet;

			// Token: 0x040009E7 RID: 2535
			public string Face;

			// Token: 0x040009E8 RID: 2536
			public string Body;

			// Token: 0x040009E9 RID: 2537
			public string Leg;

			// Token: 0x040009EA RID: 2538
			public string Boots;

			// Token: 0x040009EB RID: 2539
			public string Glove;

			// Token: 0x040009EC RID: 2540
			public string Weapon;

			// Token: 0x040009ED RID: 2541
			public string[] WeaponPoint;

			// Token: 0x040009EE RID: 2542
			public string WingPoint;

			// Token: 0x040009EF RID: 2543
			public string SecondWeapon;

			// Token: 0x040009F0 RID: 2544
			public string Wing;

			// Token: 0x040009F1 RID: 2545
			public string Tail;

			// Token: 0x040009F2 RID: 2546
			public string Decal;

			// Token: 0x040009F3 RID: 2547
			public string Hair;

			// Token: 0x040009F4 RID: 2548
			public string TailPoint;

			// Token: 0x040009F5 RID: 2549
			public string FishingPoint;

			// Token: 0x040009F6 RID: 2550
			public string[] SideWeaponPoint;

			// Token: 0x040009F7 RID: 2551
			public string RootPoint;

			// Token: 0x040009F8 RID: 2552
			public byte id;
		}
	}
}
