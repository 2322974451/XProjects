using System;

namespace XUtliPoolLib
{

	public class IBShop : CVSReader
	{

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

		public IBShop.RowData[] Table = null;

		public class RowData
		{

			public uint id;

			public uint type;

			public uint itemid;

			public uint discount;

			public uint viplevel;

			public bool bind;

			public uint levelbuy;

			public uint buycount;

			public uint refreshtype;

			public uint currencytype;

			public uint currencycount;

			public uint newproduct;

			public int sortid;

			public uint rmb;

			public string goodsid;

			public bool fashion;
		}
	}
}
