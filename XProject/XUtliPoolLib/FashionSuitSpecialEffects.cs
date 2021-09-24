using System;

namespace XUtliPoolLib
{

	public class FashionSuitSpecialEffects : CVSReader
	{

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

		public FashionSuitSpecialEffects.RowData[] Table = null;

		public class RowData
		{

			public uint suitid;

			public uint specialeffectsid;

			public string Fx1;

			public string Fx2;

			public string Fx3;

			public string Fx4;

			public string Fx5;

			public string Fx6;

			public string Fx7;

			public string Fx8;

			public string Name;

			public string Icon;

			public uint[] FashionList;
		}
	}
}
