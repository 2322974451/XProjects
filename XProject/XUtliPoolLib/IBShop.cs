using System;

namespace XUtliPoolLib
{
	// Token: 0x0200011D RID: 285
	public class IBShop : CVSReader
	{
		// Token: 0x060006E4 RID: 1764 RVA: 0x00021EDC File Offset: 0x000200DC
		public IBShop.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			IBShop.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchid(key);
			}
			return result;
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x00021F14 File Offset: 0x00020114
		private IBShop.RowData BinarySearchid(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			IBShop.RowData rowData;
			IBShop.RowData rowData2;
			IBShop.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.id == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.id == key;
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
				bool flag4 = rowData3.id.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.id.CompareTo(key) < 0;
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

		// Token: 0x060006E6 RID: 1766 RVA: 0x00021FF0 File Offset: 0x000201F0
		protected override void ReadLine(XBinaryReader reader)
		{
			IBShop.RowData rowData = new IBShop.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.type, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.discount, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.viplevel, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<bool>(reader, ref rowData.bind, CVSReader.boolParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.levelbuy, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.buycount, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.refreshtype, CVSReader.uintParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.currencytype, CVSReader.uintParse);
			this.columnno = 11;
			base.Read<uint>(reader, ref rowData.currencycount, CVSReader.uintParse);
			this.columnno = 12;
			base.Read<uint>(reader, ref rowData.newproduct, CVSReader.uintParse);
			this.columnno = 15;
			base.Read<int>(reader, ref rowData.sortid, CVSReader.intParse);
			this.columnno = 16;
			base.Read<uint>(reader, ref rowData.rmb, CVSReader.uintParse);
			this.columnno = 21;
			base.Read<string>(reader, ref rowData.goodsid, CVSReader.stringParse);
			this.columnno = 22;
			base.Read<bool>(reader, ref rowData.fashion, CVSReader.boolParse);
			this.columnno = 24;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x000221C4 File Offset: 0x000203C4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new IBShop.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000369 RID: 873
		public IBShop.RowData[] Table = null;

		// Token: 0x0200031C RID: 796
		public class RowData
		{
			// Token: 0x04000BCC RID: 3020
			public uint id;

			// Token: 0x04000BCD RID: 3021
			public uint type;

			// Token: 0x04000BCE RID: 3022
			public uint itemid;

			// Token: 0x04000BCF RID: 3023
			public uint discount;

			// Token: 0x04000BD0 RID: 3024
			public uint viplevel;

			// Token: 0x04000BD1 RID: 3025
			public bool bind;

			// Token: 0x04000BD2 RID: 3026
			public uint levelbuy;

			// Token: 0x04000BD3 RID: 3027
			public uint buycount;

			// Token: 0x04000BD4 RID: 3028
			public uint refreshtype;

			// Token: 0x04000BD5 RID: 3029
			public uint currencytype;

			// Token: 0x04000BD6 RID: 3030
			public uint currencycount;

			// Token: 0x04000BD7 RID: 3031
			public uint newproduct;

			// Token: 0x04000BD8 RID: 3032
			public int sortid;

			// Token: 0x04000BD9 RID: 3033
			public uint rmb;

			// Token: 0x04000BDA RID: 3034
			public string goodsid;

			// Token: 0x04000BDB RID: 3035
			public bool fashion;
		}
	}
}
